using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Text;

namespace AracTakipSitesi
{
    public partial class sifreyenile : System.Web.UI.Page
    {
        int id;
            string kullanici;
            SHA1 sifrele = new SHA1CryptoServiceProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            hata.Visible = false;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {


            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");
            try
            {
                BindData(email.Value.ToString());
                string veri = id.ToString() + ";" + kullanici + ";" + DateTime.Today.ToString("dd/MM/yyyy");
                string Sifreliveri = Sifrele(veri);

                SQLiteCommand sql = new SQLiteCommand("SELECT COUNT(*) FROM LOGIN where EPOSTA=@email", con);
                con.Open(); //bağlantıyı açıyoruz. 
                sql.Parameters.AddWithValue("@email", email.Value.ToString());
                int _parameter = Convert.ToInt32(sql.ExecuteScalar());

                if (_parameter == 0)
                {
                    hata.Visible = true;
                }
                else
                {

                    MailMessage mail = new MailMessage(); //yeni bir mail nesnesi Oluşturuldu.
                    mail.IsBodyHtml = true; //mail içeriğinde html etiketleri kullanılsın mı?
                    mail.To.Add(email.Value.ToString()); //Kime mail gönderilecek.

                    //mail kimden geliyor, hangi ifade görünsün?
                    mail.From = new MailAddress("bacakbusra@gmail.com", "Araç Tkip sistemi", System.Text.Encoding.UTF8);
                    mail.Subject = "Araç Tkip sistemi Şifre Yenileme";//mailin konusu

                    //mailin içeriği.. Bu alan isteğe göre genişletilip daraltılabilir.
                    mail.Body = "Şifrenizi yenileyebilmek için aşağıdaki linke tıklayınız : <br/> <a href ='http://localhost:53937/yenisifrebelirle.aspx?id=" + Sifreliveri + "'>http://localhost:53937/yenisifrebelirle.aspx?id=" + Sifreliveri +"</br> Burada Kendi Localinizi girdiğiniz taktirde Çalışacaktır </a>";
                    mail.IsBodyHtml = true;
                    SmtpClient smp = new SmtpClient();

                    //mailin gönderileceği adres ve şifresi
                    smp.Credentials = new NetworkCredential("bacakbusra58@gmail.com", "sifre"); // şifre girilecektir.
                    smp.Port = 587;
                    smp.Host = "smtp.gmail.com";//gmail üzerinden gönderiliyor.
                    smp.EnableSsl = true;
                    smp.Send(mail);//mail isimli mail gönderiliyor.

                    Label1.Text = "Lütfen mailinizi kontrol ediniz.";

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = "INSERT INTO SIFRE_YENILEME_LINK(LINK,EMAIL,AKTIF) VALUES(@link,@email,0)";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@link", Sifreliveri.ToString());
                    cmd.Parameters.AddWithValue("@email", email.Value.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception Ex)
            {
                Response.Write(Environment.NewLine + Ex.ToString());
            }
            finally
            {

                con.Close();
            }

        }
        public static string Sifrele(string data)
        {
            data = Convert.ToBase64String(Encoding.Default.GetBytes(data));
            data = reverse(data);
            byte[] dz2 = Encoding.GetEncoding(1254).GetBytes(data);
            int adl = (data.Length < 32 ? (32 - data.Length) : 0);
            byte[] dz = new byte[dz2.Length + 12 + (adl)];
            Thread.Sleep(1);
            int bdon = (DateTime.Now.Millisecond % 6) + 1; // 6
            for (int i = 0; i < 6; i++)
            {
                dz[i] = (byte)(((i + 1) * (i + 3)) + DateTime.Now.Millisecond);
                dz[6 + data.Length + i] = (byte)(((i + 5) * (i + 6)) + DateTime.Now.Millisecond);
            }
            for (int i = 0; i < dz2.Length; i++) { dz[6 + i] = dz2[i]; }
            if (adl > 0) { for (int i = dz2.Length + 12; i < dz.Length; i++) { dz[i] = (byte)((i + 7) + DateTime.Now.Millisecond); } }
            dz[2] = (byte)bdon;
            dz[3] = (byte)((data.Length >> 8) & 0x000000FF);
            dz[4] = (byte)((data.Length & 0x000000FF));
            dz[5] = (byte)(adl);
            int chrval = 0;
            for (int xx = 0; xx < dz.Length; xx++)
            {
                if (xx == 2 || xx == 3 || xx == 4 || xx == 5) continue;
                chrval = dz[xx];
                for (int i = 0; i < bdon; i++)
                {
                    chrval = (chrval >> 1) | ((chrval & 0x01) == 1 ? 0x80 : 0x00);
                }
                dz[xx] = (byte)chrval;
            }
            return viewHex(dz);
        }


        public static string viewHex(byte[] dz1)
        {
            return (BitConverter.ToString(dz1)).Replace("-", "").ToUpper();
        }
        public static string reverse(string str)
        {
            string ret = "";
            for (int i = 0; i < str.Length; i++)
            {
                ret += Convert.ToString(str[str.Length - i - 1]);
            }
            return ret;
        }

        public static string viewString(byte[] dz1, int startIndex, int dlength)
        {
            string ret = "";
            if (dz1 != null)
            {
                for (int i = 0; i < dz1.Length; i++)
                {
                    if (i < startIndex) continue;
                    if (i >= dlength) continue;
                    ret += Convert.ToChar(dz1[i]);
                }
            }
            return ret;
        }

        public void BindData(string email)

        {

            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");
            SQLiteCommand sql = new SQLiteCommand("SELECT ID,KULLANICI_ADI FROM LOGIN where EPOSTA=@email", con);
            con.Open(); //bağlantıyı açıyoruz. 
            sql.Parameters.AddWithValue("@email", email.ToString());
            SQLiteDataReader dr = sql.ExecuteReader();

            if (dr.Read())
            {

                id = (Convert.ToInt32(dr["ID"]));
                kullanici = dr["KULLANICI_ADI"].ToString();
            }
            con.Close();

        }
    }
}
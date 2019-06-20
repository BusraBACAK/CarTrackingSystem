using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AracTakipSitesi
{
    public partial class yenisifrebelirle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");
            try
            {
                string id = Request.QueryString["id"].ToString();
                string sifreveri = SifreCoz(id);
                //   Response.Write(sifreveri);
                string[] parcalar;
                parcalar = sifreveri.Split(';');


                SQLiteCommand sql = new SQLiteCommand("SELECT * FROM SIFRE_YENILEME_LINK WHERE LINK=@link", con);
                con.Open(); //bağlantıyı açıyoruz.
                sql.Parameters.AddWithValue("@link", id.ToString());
                SQLiteDataReader dr = sql.ExecuteReader();
                if (dr.Read())
                {
                    if (Convert.ToBoolean(dr["AKTIF"].ToString()) == true)
                    {
                        sifrebelirle.Visible = false;
                        yanlis.Visible = true;
                    }
                }

                if (DateTime.Today.ToString("dd/MM/yyyy") != parcalar[2].ToString())
                {
                    sifrebelirle.Visible = false;
                    yanlis.Visible = true;
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");
            string id = Request.QueryString["id"].ToString();
            string sifreveri = SifreCoz(id);
            //   Response.Write(sifreveri);
            string[] parcalar;

            parcalar = sifreveri.Split(';');

            try
            {
                SQLiteCommand sql = new SQLiteCommand("UPDATE LOGIN SET SIFRE=@sifre WHERE ID=@id", con);
                con.Open(); //bağlantıyı açıyoruz. 
                sql.Parameters.AddWithValue("@id", parcalar[0].ToString());
                sql.Parameters.AddWithValue("@sifre", password.Text);
                if (sql.ExecuteNonQuery() > 0)
                {
                    Literal1.Text = parcalar[1].ToString();
                    guncel.Visible = true;
                }

            }
            catch (Exception Ex)
            {
                Response.Write(Environment.NewLine + Ex.ToString());
            }
            finally
            {

                con.Close();
                aktifgüncelle(id);
            }

        }
        private void aktifgüncelle(string id)
        {

            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");
            SQLiteCommand sql = new SQLiteCommand("UPDATE SIFRE_YENILEME_LINK SET AKTIF=1 WHERE LINK=@link", con);
            con.Open(); //bağlantıyı açıyoruz. 
            sql.Parameters.AddWithValue("@link", id.ToString());
            sql.ExecuteNonQuery();
            con.Close();
        }
        public static string SifreCoz(string xdata)
        {
            byte[] dz = getByteArray(xdata);
            int bdon = dz[2]; // 6;
            int adl = dz[5]; // 6;
            int dl = ((dz[3] << 8) | dz[4]) + 12; // 6;
            int chrval = 0;
            for (int xx = 0; xx < dl; xx++)
            {
                chrval = dz[xx];
                for (int i = 0; i < (8 - (bdon % 8)); i++)
                {
                    chrval = (chrval >> 1) | ((chrval & 0x01) == 1 ? 0x80 : 0x00);
                }
                dz[xx] = (byte)chrval;
            }
            byte[] dz2 = new byte[dl - 12];
            for (int i = 0; i < dz2.Length; i++)
            {
                dz2[i] = dz[i + 6];
            }
            string strModified = reverse(viewString(dz2, 0, dz2.Length));
            byte[] data = Convert.FromBase64String(strModified);
            string decodedString = Encoding.UTF8.GetString(data);
            return decodedString;
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
        public static byte[] getByteArray(string hexValuePrm)
        {
            if (String.IsNullOrEmpty(hexValuePrm)) return null;
            byte[] dzret = new byte[hexValuePrm.Length / 2];
            for (int i = 0; i < dzret.Length; i++)
            {
                try { dzret[i] = (byte)Convert.ToInt32(hexValuePrm.Substring((i * 2), 2), 16); } catch (Exception) { dzret[i] = 0; }
            }
            return dzret;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.IO;

namespace AracTakipSitesi
{
    public partial class uyekayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hata.Visible = false;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");
            try
            {
                string emailnu = this.email.Value;
                con.Open(); //bağlantıyı açıyoruz.
                SQLiteCommand sql = new SQLiteCommand("SELECT COUNT(EPOSTA) FROM LOGIN where EPOSTA='" + emailnu + "'", con);
                int parameter = Convert.ToInt32(sql.ExecuteScalar());

                if (parameter != 0)
                {
                    hata.Visible = true;
                }
                else
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = "INSERT INTO LOGIN(AD_SOYAD,EPOSTA,TELEFON,KULLANICI_ADI,SIFRE,SON_GIRIS) VALUES(@isim,@email,@tel,@username,@sifre,@songiris)";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@isim", fullName.Value.ToString());
                    cmd.Parameters.AddWithValue("@email", email.Value.ToString());
                    cmd.Parameters.AddWithValue("@tel", tel.Value.ToString());
                    cmd.Parameters.AddWithValue("@username", username.Value.ToString());
                    cmd.Parameters.AddWithValue("@sifre", password.Value.ToString());
                    cmd.Parameters.AddWithValue("@songiris", DateTime.Now.ToString());

                    int basarili = cmd.ExecuteNonQuery();

                    if (basarili == 1)
                    {
                        Response.Write("<script language=javascript>alert('Kaydınız Başarıyla Oluşturuldu.')</script>");
                    Response.Redirect("login.aspx");
                        
                    }
                    else Response.Write("<script language=javascript>alert('Kaydınız oluşturulurken hata oluşmuştur lütfen tekrar deneyiniz')</script>");

                    
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

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using System.Data.SQLite;
using System.IO;

namespace AracTakipSitesi
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tableOlustur();
            hata.Visible = false;
        }

        protected void tableOlustur()
        {
            if (!File.Exists(Server.MapPath("~/bin/ARACTAKIP_DB.sqlite")))
            {
                try
                {
                    SQLiteConnection.CreateFile("ARACTAKIP_DB.sqlite");
                    SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");
                    con.Open();
                    string[] dzSQLs = {
                       "CREATE TABLE LOGIN (ID INTEGER PRIMARY KEY AUTOINCREMENT,AD_SOYAD nvarchar(50) NULL,EPOSTA nvarchar(50) NULL,TELEFON nvarchar(50) NULL,KULLANICI_ADI nvarchar(50) NULL,SIFRE nvarchar(50) NULL,SON_GIRIS nvarchar(50) NULL)",
                         "CREATE TABLE ARAC (ID INTEGER PRIMARY KEY AUTOINCREMENT,FOTO nvarchar(50) NULL,PLAKA_NUMARASI nvarchar(50) NULL,BIRIM_ADI nvarchar(50) NULL,MARKA nvarchar(50) NULL,MODEL nvarchar(50) NULL,MODEL_YILI nvarchar(50) NULL,CESIT nvarchar(50) NULL,TUR nvarchar(50) NULL,ARAC_DURUMU nvarchar(50) NULL )",
                        "CREATE TABLE SIFRE_YENILEME_LINK (ID INTEGER PRIMARY KEY AUTOINCREMENT,LINK nvarchar(100) NULL,EMAIL nvarchar(100) NULL,AKTIF bit NULL)",

                };
                    for (int i = 0; i < dzSQLs.Length; i++)
                    {
                        try
                        {
                            SQLiteCommand command = new SQLiteCommand(dzSQLs[i], con);
                            command.ExecuteNonQuery();
                        }
                        catch (Exception) { }
                    }
                    con.Close();
                    //MessageBox.Show( "DB created!" );
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                return;
            }


        }



        protected void Submit_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");
            //  Response.Write("adssd");
            try
            {
                SQLiteCommand sql = new SQLiteCommand("SELECT SIFRE FROM LOGIN WHERE KULLANICI_ADI=@kullanici", con);
                con.Open(); //bağlantıyı açıyoruz. 
                sql.Parameters.AddWithValue("@kullanici", username.Value.ToString());
                SQLiteDataReader dr = sql.ExecuteReader();

                if (dr.Read())
                {
                    if (password.Value.ToString() == dr["SIFRE"].ToString())
                    {
                        HttpCookie cerezim = new HttpCookie("cerezdosyam");
                        cerezim["kullaniciAdi"] = username.Value.ToString();
                        Response.Cookies.Add(cerezim);
                        Response.Redirect("AracTakip.aspx");
                    }
                    else { hata.Visible = true; }
                }

                else { hata.Visible = true; }
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
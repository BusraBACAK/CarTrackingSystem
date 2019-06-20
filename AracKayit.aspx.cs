using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace AracTakipSitesi
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request.Cookies["cerezdosyam"] == null)
            {
                Response.Redirect("login.aspx");
            }
            for (int i=1980;i<= DateTime.Now.Year;i++)
            DropDownList1.Items.Add(i.ToString());
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");

            con.Open();

            try
            {
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/jpg" || FileUpload1.PostedFile.ContentType == "image/png") //Burada yüklenen dosyaların resim türünde olup olmadığını kontrol ediyoruz.
                        {
                            if (FileUpload1.PostedFile.ContentLength < 5048000)
                            {
                                string filename = Path.GetFileName(FileUpload1.FileName);
                                if (filename != "")
                                {
                                    FileUpload1.SaveAs(Server.MapPath("~/image/arac/") + "arac-" + filename);
                                    Label4.Text = filename + " dosyası yüklendi!";

                                    //Response.Write("başarılı");
                                    SQLiteCommand cmd = new SQLiteCommand();
                                    cmd.CommandText = "INSERT INTO ARAC(FOTO,PLAKA_NUMARASI,BIRIM_ADI,MARKA,MODEL,MODEL_YILI,CESIT,TUR,ARAC_DURUMU) VALUES(@foto,@plaka_numara,@birim,@marka,@model,@model_yili,@cesit,@tur,@durum)";
                                    cmd.Connection = con;
                                    // cmd.Transaction = sqlTransaction;     cmd.Parameters.AddWithValue("@plaka_numara", plaka_numarasi.Text.ToString());
                                    cmd.Parameters.AddWithValue("@foto", "image/arac/arac-" + filename);
                                    cmd.Parameters.AddWithValue("@plaka_numara", plaka_numarasi.Text.ToString());
                                    cmd.Parameters.AddWithValue("@birim", birim_adi.Text.ToString());
                                    cmd.Parameters.AddWithValue("@marka", marka.Text.ToString());
                                    cmd.Parameters.AddWithValue("@model", model.Text.ToString());
                                    cmd.Parameters.AddWithValue("@model_yili", DropDownList1.SelectedValue.ToString());
                                    cmd.Parameters.AddWithValue("@cesit", RadioButtonList1.SelectedValue.ToString());
                                    cmd.Parameters.AddWithValue("@tur", RadioButtonList2.SelectedValue.ToString());
                                    cmd.Parameters.AddWithValue("@durum", RadioButtonList3.SelectedValue.ToString());

                                    int basarili = cmd.ExecuteNonQuery();

                                    if (basarili == 1)
                                    {
                                      Response.Write("<script language=javascript>alert('Aracınız Başarıyla eklendi.')</script>");
                                        bosalt();
                                    }
                                    else Response.Write("<script language=javascript>alert('Aracınız eklenirken hata oluşmuştur lütfen tekrar deeyiniz')</script>");

                                }

                            }
                            else
                                Label4.Text = "Dosya boyutu 500 KB'dan düşük olmalı!";
                        }
                        else
                            Label4.Text = "Sadece JPEG,jpg ve png formatı kabul edilir.";
                    }
                    catch (Exception ex)
                    {
                        Label4.Text = "Dosya yüklenemedi: " + ex.Message;
                    }
                }
            }
            //sqlTransaction.Commit();


            catch (Exception Ex)
            {
                //sqlTransaction.Rollback();

                // MessageBox.Show(Environment.NewLine + Ex.ToString());

            }
            finally
            {
                con.Close();
            }
        }
        public void bosalt()
        {
            plaka_numarasi.Text = "";
            birim_adi.Text="";
            marka.Text="";
            model.Text="";
             DropDownList1.SelectedIndex=0;
             RadioButtonList1.ClearSelection();
            RadioButtonList2.ClearSelection();
            RadioButtonList3.ClearSelection();
        }
    }
}
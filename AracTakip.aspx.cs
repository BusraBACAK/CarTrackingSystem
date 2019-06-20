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
    public partial class WebForm2 : System.Web.UI.Page
    {

        private DataTable dtData = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1980; i <= DateTime.Now.Year; i++)
                DropDownList1.Items.Add(i.ToString());

            if (Request.Cookies["cerezdosyam"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!Page.IsPostBack)

            {
               Session["DTDATA"] = null;
                BindData();
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                if (Session["DTDATA"] != null)
                {
                    dtData = Session["DTDATA"] as DataTable;
                }
            }
        }
        public void BindData()

        {

            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");
            try

            {

                con.Open();



                SQLiteDataAdapter da = new SQLiteDataAdapter("select * from ARAC", con);

                dtData = new DataTable();

                da.Fill(dtData);
                Session["DTDATA"] = dtData;

                GridView1.DataSource = dtData;

                GridView1.DataBind();
                //GridView1.Focus();

                dtData.PrimaryKey = new DataColumn[] { dtData.Columns["ID"] };

            }

            catch (Exception ex)

            {

                Response.Write(ex.Message.ToString());

            }

            finally

            {

                con.Close();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            plaka_numarasi.Text = "";
            Button2.Visible = false;
            Button7.Visible = false;
            Button8.Visible = false;
            Button9.Visible = true;
        }
        protected void Foto_Guncelle(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");
            con.Open();

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
                                cmd.CommandText = "UPDATE ARAC SET FOTO=@rsm WHERE ID=@id";
                                cmd.Connection = con;
                                // cmd.Transaction = sqlTransaction;
                                cmd.Parameters.AddWithValue("@rsm", "image/arac/arac-" + filename);
                                cmd.Parameters.AddWithValue("@id", Application["id"].ToString());
                                int basarili = cmd.ExecuteNonQuery();
                                if (basarili == 1)
                                {
                                    Response.Write("<script language=javascript>alert('Aracınızın fotografı güncellendi eklendi.')</script>");
                                    
                                }
                                else Response.Write("<script language=javascript>alert('aracınızın fotografı güncellenirken hata oluştu.')</script>");
                                fotograf.ImageUrl = Server.MapPath("~/image/arac/arac-" + filename);
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

                finally
                {
                    con.Close();
                    BindData();
                }
            }

        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");
            try
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "UPDATE ARAC SET PLAKA_NUMARASI=@plaka_numara, BIRIM_ADI=@birim, MARKA=@marka, MODEL=@model, MODEL_YILI=@model_yili, CESIT=@cesit, TUR=@tur, ARAC_DURUMU=@durum WHERE ID=@id";

                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@plaka_numara", plaka_numarasi.Text.ToString());
                cmd.Parameters.AddWithValue("@birim", birim_adi.Text.ToString());
                cmd.Parameters.AddWithValue("@marka", marka.Text.ToString());
                cmd.Parameters.AddWithValue("@model", model.Text.ToString());
                cmd.Parameters.AddWithValue("@model_yili", DropDownList1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@cesit", RadioButtonList1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@tur", RadioButtonList2.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@durum", RadioButtonList3.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@id", Application["id"].ToString());
                int basarili = cmd.ExecuteNonQuery();
                if (basarili == 1)
                {
                    Response.Write("<script language=javascript>alert('Aracınız Başarıyla güncellendi.')</script>");
                  
                }
                else Response.Write("<script language=javascript>alert('Aracınız güncellenirken hata oluştu lütfen tekrar deeyiniz')</script>");

                MultiView1.ActiveViewIndex = 0;
            }

            catch (Exception Ex)
            {
                Response.Write(Environment.NewLine + Ex.ToString());
            }
            finally
            {

                con.Close();
                BindData();
            }

        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=" + Server.MapPath("~/bin/ARACTAKIP_DB.sqlite") + ";Version=3;");

            try
            {
                con.Open();
                // MessageBox.Show(grp.owner.ToString());
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "DELETE FROM ARAC WHERE ID=@id";
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@id", Application["id"].ToString());
                MultiView1.ActiveViewIndex = 0;
                int basarili = cmd.ExecuteNonQuery();
                if (basarili == 1)
                {
                    Response.Write("<script language=javascript>alert('Silme İşleminiz gerçekleşti')</script>");
                 
                }
                else Response.Write("<script language=javascript>alert('Silme işleminiz gerçekleştirilemedi.')</script>");

            }
            catch (Exception Ex)
            {
                Response.Write(Environment.NewLine + Ex.ToString());
            }
            finally
            {

                con.Close();
                BindData();
            }
        }
       
        protected void Button9_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.SelectedDataKey == null) throw new Exception("Key değeri geçersiz!");
                if (GridView1.SelectedDataKey.Value == null) throw new Exception("Key değeri geçersiz!!");

                int keyVal = Convert.ToInt32(GridView1.SelectedDataKey.Value.ToString());

                DataRow dr = dtData.Rows.Find(keyVal);
                if (dr == null) throw new Exception("Satır bulunamadı!");

                // GridViewRow row = GridView1.SelectedRow;
                Application["id"] =keyVal;
                //Session["id"] = keyVal;  GridView1.SelectedRow.Cells[1].Text;
                plaka_numarasi.Text = dr["PLAKA_NUMARASI"].ToString(); // GridView1.SelectedRow.Cells[3].Text;
                birim_adi.Text= dr["BIRIM_ADI"].ToString();//  FOTO
                marka.Text = dr["MARKA"].ToString();
                model.Text= dr["MODEL"].ToString();
                DropDownList1.SelectedValue = dr["MODEL_YILI"].ToString();
                RadioButtonList1.SelectedValue = dr["CESIT"].ToString();
                RadioButtonList2.SelectedValue = dr["TUR"].ToString();
                RadioButtonList3.SelectedValue= dr["ARAC_DURUMU"].ToString();
                fotograf.ImageUrl= dr["FOTO"].ToString();

                MultiView1.ActiveViewIndex = 1;
                Button9.Visible = true;
                Button7.Visible = true;
                Button2.Visible = true;
                Button8.Visible = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex >= 0)
            {
                GridView1.DataSource = dtData;
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
        }
    
}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AracTakipSitesi
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cerezOku = Request.Cookies["cerezdosyam"];

                lblAd.Text = "Hoşgeldiniz " + cerezOku["kullaniciAdi"].ToString();
         }
        protected void cikis_Click(object sender, EventArgs e)
        {

            if (Request.Cookies["cerezdosyam"] != null)
            {
                Request.Cookies["cerezdosyam"].Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(Request.Cookies["cerezdosyam"]);
                Response.Redirect("login.aspx");
            }
            
        }



    }
}
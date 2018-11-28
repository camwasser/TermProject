using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeadBook
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // prevents user from directly accessing a url without a session object
            //      - will need to be added to every page other than login
            if (!IsPostBack && (Session["Username"] == null))
            {
                Response.Redirect("Login_Register.aspx");
            }
            //if (!IsPostBack && (Session["Username"] != null))
            //{
            //    string font = Convert.ToString(Session["Font"]);
            //    string background = Convert.ToString(Session["Background"]);
            //    string fontColor = Convert.ToString(Session["FontColor"]);
            //    frmProfile.Style[HtmlTextWriterStyle.FontFamily] = "Arial";
            //    frmProfile.Style[HtmlTextWriterStyle.BackgroundColor] = "black";
            //    frmProfile.Style[HtmlTextWriterStyle.Color] = "" + fontColor + "";
            //    this.frmProfile.Attributes.Add("style", "font-family:" + font + ";");
            //    this.frmProfile.Attributes.Add("style", "background-color:" + background + ";");
            //    this.frmProfile.Attributes.Add("style", "color:" + fontColor + ";");

            //}
            



        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Register.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Objects;

namespace HeadBook
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // prevents user from directly accessing a url without a session object
            //      - will need to be added to every page other than login
            if (!IsPostBack && (Session["Username"] == null))
            {
                Response.Redirect("Login_Register.aspx");
            }

            if (!IsPostBack && (Session["Username"] != null))
            {
                if (Objects.Settings.LoadCurrentUserSettings(Convert.ToString(Session["Username"])) == null)
                {
                    return;

                }
                else
                {
                    DataSet ds = Objects.Settings.LoadCurrentUserSettings(Convert.ToString(Session["Username"]));

                    ddlAutoLogin.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Auto_Login"]);
					ddlEmailSetting.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Email_Notifications"]);
					ddlPhotos.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Photo_Privacy"]);
                    ddlProfileInfo.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ProfileInfo_Privacy"]);
                    ddlContactInfo.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ContactInfo_Privacy"]);
                    ddlFont.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Font_Type"]);
                    ddlBackgroundColor.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Background_Color"]);
                    ddlFontColor.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Font_Color"]);
                    //string font = Convert.ToString(Session["Font"]);
                    //string background = Convert.ToString(Session["Background"]);
                    //string fontColor = Convert.ToString(Session["FontColor"]);
                    //this.frmSettings.Attributes.Add("style", "font-family:" + font + ";");
                    //this.frmSettings.Attributes.Add("style", "background-color:" + background + ";");
                    //this.frmSettings.Attributes.Add("style", "color:" + fontColor + ";");

                }
            }
        }
        

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Register.aspx");
        }

        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            
            lblError.Text = Objects.Settings.SaveUserSettings(Convert.ToString(Session["Username"]), ddlEmailSetting.SelectedValue, ddlAutoLogin.SelectedValue, ddlPhotos.SelectedValue, ddlProfileInfo.SelectedValue, ddlContactInfo.SelectedValue, ddlFont.SelectedValue, ddlBackgroundColor.SelectedValue, ddlFontColor.SelectedValue);
        }
   
    }
}
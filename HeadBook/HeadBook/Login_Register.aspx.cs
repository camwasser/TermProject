
using Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeadBook
{
    public partial class Login_Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // clear error text and clear any session objects
            lblError.Text = "";
            
            if (!IsPostBack && Request.Cookies["userCookie"] != null)
            {
                lblError.Text = "";
                HttpCookie reqCook = Request.Cookies["userCookie"];
                txtUserName.Text = reqCook.Values["UserName"].ToString();
                // lblCookie.Text = "You last visited " + reqCook.Values["LastVisited"].ToString();
            }
        }

        // ***********click event for forgot password button*************
        //      - store username in session object
        //      - redirect to forgot password page
        protected void btnForgotPW_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            if (!(Objects.User.CheckUserExists(username)))
            {
                lblLoginError.Text = "This username does not exist in our database";
                txtUserName.Text = "";
                txtPassword.Text = "";
                return;
            }
            Session["Username"] = txtUserName.Text;
            Response.Redirect("Forgot_Password.aspx");
        }

        // ***********click event for register user button**************
        //      - store entries by user into a User object 
        //          - makes call to User class boolean method to enter user into database
        //              - if true returned, redirect back to login page
        //                  - if false returned, username is a duplicate and must be re-entered
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            User thisUser = new User();
            thisUser.UserName = txtEmailRegister.Text;
            thisUser.Password = txtPasswordRegister.Text;
            thisUser.FirstName = txtFirstName.Text;
            thisUser.LastName = txtLastName.Text;
            thisUser.Sec1Q = txtSecQuestion1.Text;
            thisUser.Sec2Q = txtSecQuestion2.Text;
            thisUser.Sec3Q = txtSecQuestion3.Text;
            thisUser.Sec1A = txtSecAnswer1.Text;
            thisUser.Sec2A = txtSecAnswer2.Text;
            thisUser.Sec3A = txtSecAnswer3.Text;
            thisUser.Address = txtAddress.Text;
            thisUser.City = txtCity.Text;
            thisUser.State = ddlStates.SelectedValue;
            thisUser.Org = txtOrganization.Text;
            thisUser.PhoneNum = Convert.ToString(txtPhone.Text);
            if (!Objects.User.UserRegistration(thisUser))
            {
                lblError.Text = "There is already a user with this username/email!";
                txtEmailRegister.Text = "";
            }
            else
            {
                lblLoginError.Text = "User account created!";
                lblLoginError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "User account created!";
                lblError.ForeColor = System.Drawing.Color.Green;
                txtEmailRegister.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtOrganization.Text = "";
                txtAddress.Text = "";
                txtPasswordRegister.Text = "";
                txtPhone.Text = "";
                txtSecAnswer1.Text = "";
                txtSecAnswer2.Text = "";
                txtSecAnswer3.Text = "";
                txtSecQuestion1.Text = "";
                txtSecQuestion2.Text = "";
                txtSecQuestion3.Text = "";            
            }
            

        }
        //      ***************click event for login button***********
        protected void btnSignIn_Click1(object sender, EventArgs e)
        {
            // get values entered in login 
            string username = txtUserName.Text;
            string pw = txtPassword.Text;

            // if user does not exist 
            if (!(Objects.User.CheckUserExists(username)))
            {
                lblLoginError.Text = "This username does not exist in our database";
                txtUserName.Text = "";
                txtPassword.Text = "";
                return;
            }
            // if user does exist, check password
            else
            {   // if pw NOT CORRECT
                if (!(Objects.Password.CheckPassword(username, pw)))
                {
                    lblLoginError.Text = "Incorrect password!";
                    txtPassword.Text = "";
                    return;
                }
                else // if pw CORRECT
                {
                    // create cookie
                    HttpCookie loginCookie = new HttpCookie("userCookie");

                    // add user name and current time to cookie
                    loginCookie.Values["Username"] = txtUserName.Text;
                    loginCookie.Values["LastVisited"] = DateTime.Now.ToString();

                    // if user wishes to be rmemebered
                    if (chkRememberMe.Checked)
                    {
                        // cookie expires in 7 days
                        loginCookie.Expires = DateTime.Now.AddDays(7);
                        //lblCookie.Text = "Cookie saved!";
                    }
                    else
                    {
                        // cookie immediately becomes expired
                        loginCookie.Expires = DateTime.Now.AddDays(-1);
                        //lblCookie.Text = "Cookie not saved!";
                    }
                    // add cookie to HD
                    Response.Cookies.Add(loginCookie);

                    // create session for user
                    Session["Username"] = txtUserName.Text;                   

                    // load user theme settings and add to session
                    DataSet ds = Objects.Settings.LoadCurrentUserSettings(txtUserName.Text);
                    if (ds != null)
                    {
                        Session["Font"] = Convert.ToString(ds.Tables[0].Rows[0]["Font_Type"]);
                        Session["Background"] = Convert.ToString(ds.Tables[0].Rows[0]["Background_Color"]);
                        Session["FontColor"] = Convert.ToString(ds.Tables[0].Rows[0]["Font_Color"]);
                    }
                    
                    // redirect to Profile
                    Response.Redirect("Profile.aspx", true);
                }
            }
        }
    }
}
using System;
using Objects;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeadBook
{
    public partial class Forgot_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // takes user from Session obj
                string userName = Convert.ToString(Session["Username"]);
                DataSet ds = Password.GetSecQ(userName);

                // displays corresponding security questions
                lblSecQuestion1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Sec1Q"]);
                lblSecQuestion2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Sec2Q"]);
                lblSecQuestion3.Text = Convert.ToString(ds.Tables[0].Rows[0]["Sec3Q"]);
            }
        }

        protected void btnGetPassword_Click(object sender, EventArgs e)
        {
            // takes user from Session obj
            string userName = Convert.ToString(Session["Username"]);
            DataSet ds = Password.GetSecQ(userName);

            // get submitted answers from form
            string answer1 = txtSecAnswer1.Text.ToUpper();
            string answer2 = txtSecAnswer2.Text.ToUpper();
            string answer3 = txtSecAnswer3.Text.ToUpper();

            // correct answers from db
            string sec1A = Convert.ToString(ds.Tables[0].Rows[0]["Sec1A"]).ToUpper();
            string sec2A = Convert.ToString(ds.Tables[0].Rows[0]["Sec2A"]).ToUpper();
            string sec3A = Convert.ToString(ds.Tables[0].Rows[0]["Sec3A"]).ToUpper();

            if (answer1 != sec1A)
            {
                lblError.Text = "Security Answer 1 incorrect!";
                txtSecAnswer1.Text = "";
                return;
            }
            if (answer2 != sec2A)
            {
                lblError.Text = "Security Answer 2 incorrect!";
                txtSecAnswer2.Text = "";
                return;
            }
            if (answer3 != sec3A)
            {
                lblError.Text = "Security Answer 3 incorrect!";
                txtSecAnswer3.Text = "";
                return;
            }
            else if((answer1 == sec1A) && (answer2 == sec2A) && (answer3 == sec3A))
            {
                lblError.Text = "Your password is: " + Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
            }

        }
    }
}
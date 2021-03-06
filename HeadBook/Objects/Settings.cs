﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Objects
{
    public class Settings
    {
        private string userName;
        private string autoLogin;
        private string photoPrivacy;
        private string profilePrivacy;
        private string contactPrivacy;

        public Settings()
        {

        }

        public Settings(string autoLogin, string photoPrivacy, string profilePrivacy, string contactPrivacy)
        {
            this.autoLogin = autoLogin;
            this.photoPrivacy = photoPrivacy;
            this.profilePrivacy = profilePrivacy;
            this.contactPrivacy = contactPrivacy;
        }

        public string UserName { get => userName; set => userName = value; }
        public string AutoLogin { get => autoLogin; set => autoLogin = value; }
        public string PhotoPrivacy { get => photoPrivacy; set => photoPrivacy = value; }
        public string ProfilePrivacy { get => profilePrivacy; set => profilePrivacy = value; }
        public string ContactPrivacy { get => contactPrivacy; set => contactPrivacy = value; }

        //Updates user setting preferences
        public static String SaveUserSettings(string username, string autoLogin, string photoPrivacy, string profilePrivacy, string contactPrivacy, string font, string background, string fontColor)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPUpdateUserSettings";

            // add param
            objCommand.Parameters.AddWithValue("@username", username);
            objCommand.Parameters.AddWithValue("@autoLogin", autoLogin);
            objCommand.Parameters.AddWithValue("@photoPrivacy", photoPrivacy);
            objCommand.Parameters.AddWithValue("@profilePrivacy", profilePrivacy);
            objCommand.Parameters.AddWithValue("@contactPrivacy", contactPrivacy);
            objCommand.Parameters.AddWithValue("@font", font);
            objCommand.Parameters.AddWithValue("@bg", background);
            objCommand.Parameters.AddWithValue("@fontColor", fontColor);
            int retNum = objDB.DoUpdateUsingCmdObj(objCommand);

            if (retNum == -1)
            {
                return "User Settings Not Saved!";
            }

            return "User Settings Saved!";
        }

        public static DataSet LoadCurrentUserSettings(string username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPGetUserSettings";

            // add param
            objCommand.Parameters.AddWithValue("@username", username);

            // output param
            SqlParameter result = new SqlParameter("@result", DbType.Int32);
            result.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(result);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            int retVal =Convert.ToInt32(objCommand.Parameters["@result"].Value);

            if (retVal == 0)
            {
                return null;
            }

            return ds;

           
            
        }
    }

    
}

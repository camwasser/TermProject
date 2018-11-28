using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Objects
{
    public class Password
    {
        public static DataSet GetSecQ (string user)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPGetSecurityQuestions";
            objCommand.Parameters.AddWithValue("@user", user);
            SqlParameter result = new SqlParameter("@result", DbType.Int32);
            result.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(result);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        // gets corresponding sec questions from db
        // returns a ds to cb to be checked against submitted answers
        public static DataSet CheckSecAnswers (string user)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPGetUserInfo";
            objCommand.Parameters.AddWithValue("@user", user);
            SqlParameter result = new SqlParameter("@result", DbType.Int32);
            result.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(result);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        // check password method
        //     - gets user ds and checks to see if entered pw matches pw from db
        public static Boolean CheckPassword (string user, string pw)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPGetUserInfo";
            objCommand.Parameters.AddWithValue("@user", user);

            // output param
            SqlParameter result = new SqlParameter("@result", DbType.Int32);
            result.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(result);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            string pwDb = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);

            // if pw does not match return false
            if (pwDb != pw)
            {
                return false;
            }
            // if pws match return true
            return true;
        }

    }
}

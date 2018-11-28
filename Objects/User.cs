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
	public class User
	{
		// attributes of user
		private string userName;
		private string password;
		private string firstName;
		private string lastName;
		private string address;
		private string city;
		private string state;
		private string org;
		private string phoneNum;
		private string sec1Q;
		private string sec2Q;
		private string sec3Q;
		private string sec1A;
		private string sec2A;
		private string sec3A;

		private List<String> photoList;

		public User()
		{
		}

		public User(string userName, string password, string firstName, string lastName, string address, string city, string state, string org, string phoneNum, string sec1Q, string sec2Q, string sec3Q, string sec1A, string sec2A, string sec3A)
		{
			this.userName = userName;
			this.password = password;
			this.firstName = firstName;
			this.lastName = lastName;
			this.address = address;
			this.city = city;
			this.state = state;
			this.org = org;
			this.phoneNum = phoneNum;
			this.sec1Q = sec1Q;
			this.sec2Q = sec2Q;
			this.sec3Q = sec3Q;
			this.sec1A = sec1A;
			this.sec2A = sec2A;
			this.sec3A = sec3A;
		}

		public string UserName { get => userName; set => userName = value; }
		public string Password { get => password; set => password = value; }
		public string FirstName { get => firstName; set => firstName = value; }
		public string LastName { get => lastName; set => lastName = value; }
		public string Address { get => address; set => address = value; }
		public string PhoneNum { get => phoneNum; set => phoneNum = value; }
		public string Sec1Q { get => sec1Q; set => sec1Q = value; }
		public string Sec2Q { get => sec2Q; set => sec2Q = value; }
		public string Sec3Q { get => sec3Q; set => sec3Q = value; }
		public string Sec1A { get => sec1A; set => sec1A = value; }
		public string Sec2A { get => sec2A; set => sec2A = value; }
		public string Sec3A { get => sec3A; set => sec3A = value; }
		public string City { get => city; set => city = value; }
		public string State { get => state; set => state = value; }
		public string Org { get => org; set => org = value; }
		public List<string> PhotoList { get => photoList; set => photoList = value; }


		// User Registration method
		//  -Called from cb of Login_Register
		//    - Returns false if username already exists
		//      - Returns true if record added successfully
		public static Boolean UserRegistration(User thisUser)
		{
			DBConnect objDB = new DBConnect();
			SqlCommand objCommand = new SqlCommand();
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPRegisterUser";

			// attributes of User object
			objCommand.Parameters.AddWithValue("@username", thisUser.UserName);
			objCommand.Parameters.AddWithValue("@password", thisUser.Password);
			objCommand.Parameters.AddWithValue("@first", thisUser.FirstName);
			objCommand.Parameters.AddWithValue("@last", thisUser.LastName);
			objCommand.Parameters.AddWithValue("@address", thisUser.Address);
			objCommand.Parameters.AddWithValue("@city", thisUser.City);
			objCommand.Parameters.AddWithValue("@state", thisUser.State);
			objCommand.Parameters.AddWithValue("@org", thisUser.Org);
			objCommand.Parameters.AddWithValue("@phone", thisUser.PhoneNum);
			objCommand.Parameters.AddWithValue("@sec1Q", thisUser.Sec1Q);
			objCommand.Parameters.AddWithValue("@sec1A", thisUser.Sec1A);
			objCommand.Parameters.AddWithValue("@sec2Q", thisUser.Sec2Q);
			objCommand.Parameters.AddWithValue("@sec2A", thisUser.Sec2A);
			objCommand.Parameters.AddWithValue("@sec3Q", thisUser.Sec3Q);
			objCommand.Parameters.AddWithValue("@sec3A", thisUser.Sec3A);

			// output parameter used to gauge success of procedure
			SqlParameter result = new SqlParameter("@result", DbType.Int32);
			result.Direction = ParameterDirection.Output;
			objCommand.Parameters.Add(result);
			objDB.DoUpdateUsingCmdObj(objCommand);

			// get value of output param
			int returnVal = Convert.ToInt32(objCommand.Parameters["@result"].Value);

			// if username exists, return false
			if (returnVal == 0)
			{
				return false;
			}
			return true;

		}

		// Check if user exists
		//    Return false if user DOESNT exist
		//      Returns true if user exists
		public static Boolean CheckUserExists(string username)
		{
			DBConnect objDB = new DBConnect();
			SqlCommand objCommand = new SqlCommand();
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPGetUserInfo";

			// add param
			objCommand.Parameters.AddWithValue("@user", username);

			// output parameter used to gauge success of procedure
			SqlParameter result = new SqlParameter("@result", DbType.Int32);
			result.Direction = ParameterDirection.Output;
			objCommand.Parameters.Add(result);
			DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

			// get value of output param
			int returnVal = Convert.ToInt32(objCommand.Parameters["@result"].Value);

			if (returnVal == 0)
			{
				return false;
			}
			return true;
		}

		//Returns a user's information
		public static DataSet GetUserInfo(string username)
		{
			DBConnect objDB = new DBConnect();
			SqlCommand objCommand = new SqlCommand();
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPGetUserInfo";

			// add param
			objCommand.Parameters.AddWithValue("@user", username);

			// output parameter used to gauge success of procedure
			SqlParameter result = new SqlParameter("@result", DbType.Int32);
			result.Direction = ParameterDirection.Output;
			objCommand.Parameters.Add(result);
			DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

			// get value of output param
			int returnVal = Convert.ToInt32(objCommand.Parameters["@result"].Value);

			if (returnVal == 0)
			{
				return null;
			}
			return ds;
		}



		public static DataSet FindUsersByFirstName(string firstname)
		{
			DBConnect db = new DBConnect();
			SqlCommand userobj = new SqlCommand();
			userobj.CommandType = System.Data.CommandType.StoredProcedure;
			userobj.CommandText = "TPGetUsersByFirstName";
			userobj.Parameters.AddWithValue("@firstname", firstname);

			SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
			outputParameter.Direction = System.Data.ParameterDirection.Output;
			userobj.Parameters.Add(outputParameter);

			DataSet ds = db.GetDataSetUsingCmdObj(userobj);

			int retVal = Convert.ToInt32(userobj.Parameters["@result"].Value);

			if (retVal == 0)
			{
				return null;
			}

			return ds;

		}

		//Finds users by their city and state
		public static DataSet FindUsersByLocation(string city, string state)
		{
			DBConnect db = new DBConnect();
			SqlCommand userobj = new SqlCommand();
			userobj.CommandType = System.Data.CommandType.StoredProcedure;
			userobj.CommandText = "TPGetUsersByLocation";
			userobj.Parameters.AddWithValue("@city", city);
			userobj.Parameters.AddWithValue("@state", state);

			SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
			outputParameter.Direction = System.Data.ParameterDirection.Output;
			userobj.Parameters.Add(outputParameter);

			DataSet ds = db.GetDataSetUsingCmdObj(userobj);

			int retVal = Convert.ToInt32(userobj.Parameters["@result"].Value);

			if (retVal == 0)
			{
				return null;
			}

			return ds;

		}

		//Finds users by their organization
		public static DataSet FindUsersByOrganization(string organization)
		{
			DBConnect db = new DBConnect();
			SqlCommand userobj = new SqlCommand();
			userobj.CommandType = System.Data.CommandType.StoredProcedure;
			userobj.CommandText = "TPGetUsersByLocation";
			userobj.Parameters.AddWithValue("@organization", organization);

			SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
			outputParameter.Direction = System.Data.ParameterDirection.Output;
			userobj.Parameters.Add(outputParameter);

			DataSet ds = db.GetDataSetUsingCmdObj(userobj);

			int retVal = Convert.ToInt32(userobj.Parameters["@result"].Value);

			if (retVal == 0)
			{
				return null;
			}

			return ds;

		}

		//Finds a requested user's friends
		public static DataSet GetFriends(string RequestedUsername)
		{
			DBConnect db = new DBConnect();
			SqlCommand userobj = new SqlCommand();
			userobj.CommandType = System.Data.CommandType.StoredProcedure;
			userobj.CommandText = "TPGetFriends";
			userobj.Parameters.AddWithValue("@RequestedUsername", RequestedUsername);

			SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
			outputParameter.Direction = System.Data.ParameterDirection.Output;
			userobj.Parameters.Add(outputParameter);

			DataSet ds = db.GetDataSetUsingCmdObj(userobj);

			int retVal = Convert.ToInt32(userobj.Parameters["@result"].Value);

			if (retVal == 0)
			{
				//Has no friends
				return null;
			}

			return ds;

		}

		//Finds a requested user's friends as list of user objects
		public static List<User> GetFriendsList(string RequestedUsername)
		{
			//Get's all user's friends
			DBConnect db = new DBConnect();
			SqlCommand userobj = new SqlCommand();
			userobj.CommandType = System.Data.CommandType.StoredProcedure;
			userobj.CommandText = "TPGetFriends";
			userobj.Parameters.AddWithValue("@RequestedUsername", RequestedUsername);

			SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
			outputParameter.Direction = System.Data.ParameterDirection.Output;
			userobj.Parameters.Add(outputParameter);

			DataSet ds = db.GetDataSetUsingCmdObj(userobj);

			int retVal = Convert.ToInt32(userobj.Parameters["@result"].Value);

			if (retVal == 0)
			{
				//Has no friends
				return null;
			}

			//////////////////////////////////////////////////////////////////////////

			//Create list of friends(Users)
			List<User> friendsList = new List<User>();
			User friend;

			//For each friend, get the friend's information and add them to the friends list
			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				DBConnect dbConn = new DBConnect();
				SqlCommand userInfoobj = new SqlCommand();
				userInfoobj.CommandType = System.Data.CommandType.StoredProcedure;
				userInfoobj.CommandText = "TPGetUserInfo";
				userInfoobj.Parameters.AddWithValue("@user", ds.Tables[0].Rows[i]["UserName"]);

				SqlParameter outputParam = new SqlParameter("@result", DbType.Int32);
				outputParam.Direction = System.Data.ParameterDirection.Output;
				userobj.Parameters.Add(outputParam);

				DataSet dataSet = db.GetDataSetUsingCmdObj(userInfoobj);

				int retNum = Convert.ToInt32(userobj.Parameters["@result"].Value);

				//Requested user's photos
				List<String> photoSet = Photos.userPhotoList(RequestedUsername);

				friend = new User();

				friend.UserName = Convert.ToString(dataSet.Tables[0].Rows[i]["Username"]);
				friend.Password = Convert.ToString(dataSet.Tables[0].Rows[i]["Password"]);
				friend.FirstName = Convert.ToString(dataSet.Tables[0].Rows[i]["FirstName"]);
				friend.LastName = Convert.ToString(dataSet.Tables[0].Rows[i]["LastName"]);
				friend.Address = Convert.ToString(dataSet.Tables[0].Rows[i]["StreetAddress"]);
				friend.City = Convert.ToString(dataSet.Tables[0].Rows[i]["City"]);
				friend.State = Convert.ToString(dataSet.Tables[0].Rows[i]["State"]);
				friend.Org = Convert.ToString(dataSet.Tables[0].Rows[i]["Organization"]);
				friend.PhoneNum = Convert.ToString(dataSet.Tables[0].Rows[i]["Phone"]);
				friend.PhotoList = photoSet;

				friendsList.Add(friend);
			}

			return friendsList;
		}

		//Determines if two users are friends
		public static Boolean IsFriend(string RequestingUsername, string RequestedUsername)
		{
			DBConnect db = new DBConnect();
			SqlCommand userobj = new SqlCommand();
			userobj.CommandType = System.Data.CommandType.StoredProcedure;
			userobj.CommandText = "TPIsFriend";
			userobj.Parameters.AddWithValue("@requestingUsername", RequestingUsername);
			userobj.Parameters.AddWithValue("@requestedUsername", RequestedUsername);

			SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
			outputParameter.Direction = System.Data.ParameterDirection.Output;
			userobj.Parameters.Add(outputParameter);

			DataSet ds = db.GetDataSetUsingCmdObj(userobj);

			int retVal = Convert.ToInt32(userobj.Parameters["@result"].Value);

			if (retVal == 0)
			{
				//These users are friends
				return false;
			}
			//These users
			return true;
		}

		//Determines if requesting username is a friend of a friend
		public static Boolean IsFriendOfFriend(string RequestingUsername, string RequestedUsername)
		{
			DBConnect db = new DBConnect();
			SqlCommand userobj = new SqlCommand();
			userobj.CommandType = System.Data.CommandType.StoredProcedure;
			userobj.CommandText = "TPGetFriends";
			userobj.Parameters.AddWithValue("@requestedUsername", RequestedUsername);

			SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
			outputParameter.Direction = System.Data.ParameterDirection.Output;
			userobj.Parameters.Add(outputParameter);

			DataSet ds = db.GetDataSetUsingCmdObj(userobj);

			//Requested username friends list
			List<String> requestedUsernameFriendList = new List<String>();


			//Add all requested username friends into list
			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				requestedUsernameFriendList.Add(Convert.ToString(ds.Tables[0].Rows[i]["FriendUserName"]));

			}

			//For every friend in the requested username's friend list
			foreach (String friend in requestedUsernameFriendList)
			{
				DBConnect dbConn = new DBConnect();
				SqlCommand userComobj = new SqlCommand();
				userComobj.CommandType = System.Data.CommandType.StoredProcedure;
				userComobj.CommandText = "TPGetFriends";
				userComobj.Parameters.AddWithValue("@requestedUsername", friend);

				SqlParameter outputParam = new SqlParameter("@result", DbType.Int32);
				outputParam.Direction = System.Data.ParameterDirection.Output;
				userComobj.Parameters.Add(outputParam);

				DataSet friendsListDataSet = db.GetDataSetUsingCmdObj(userobj);

				//If retVal = 1, it returns a dataset of the friends
				int retVal = Convert.ToInt32(userComobj.Parameters["@result"].Value);

				if (retVal == 1)
				{
					//For each friend in one of the requested username's friend's friend list, check to see if one of their friends is the 
					//requesting username
					for (int i = 0; i < friendsListDataSet.Tables[0].Rows.Count; i++)
					{
						if(RequestingUsername == Convert.ToString(friendsListDataSet.Tables[0].Rows[i]["FriendUserName"]))
						{
							return true;
						}
					}
				}
				
			}

			return false;	
		}
	}
}

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
	public class Photos
	{
		//Holds an single user's photos as links to the image file destination in project solution
		List<String> photoList;

		public Photos()
		{

		}

		public Photos(List<String> photoList)
		{
			this.photoList = photoList;
		}

		public List<String> PhotoList { get => photoList; set => photoList = value; }

		public static List<String> userPhotoList(string username)
		{
			DBConnect db = new DBConnect();
			SqlCommand userobj = new SqlCommand();
			userobj.CommandType = System.Data.CommandType.StoredProcedure;
			userobj.CommandText = "TPGetPhotos";
			userobj.Parameters.AddWithValue("@username", username);

			DataSet ds = db.GetDataSetUsingCmdObj(userobj);

			List<String> photoList = new List<String>();

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				photoList.Add(Convert.ToString(ds.Tables[0].Rows[0]["ProfilePhoto"]));
				photoList.Add(Convert.ToString(ds.Tables[0].Rows[0]["PhotoLink1"]));
				photoList.Add(Convert.ToString(ds.Tables[0].Rows[0]["PhotoLink2"]));
				photoList.Add(Convert.ToString(ds.Tables[0].Rows[0]["PhotoLink3"]));
			}

			return photoList;
		}
	}
}

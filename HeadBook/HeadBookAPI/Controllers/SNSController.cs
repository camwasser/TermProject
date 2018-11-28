using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Objects;

namespace HeadBookAPI.Controllers
{
	[Route("api/[controller]")]
	public class SNSController : Controller
	{
		// GET api/SocialNetworkService
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/SocialNetworkService/FindUsersByName?firstname=XXXXX
		[HttpGet("FindUsersByName")]
		public DataSet FindUsersByName(string firstname)
		{
			return Objects.User.FindUsersByFirstName(firstname);
		}

		// GET api/SocialNetworkService/FindUsersByLocation?city=XXX&state=XXX
		[HttpGet("FindUsersByLocation")]
		public DataSet FindUsersByLocation(string city, string state)
		{
			return Objects.User.FindUsersByLocation(city, state);
		}

		// GET api/SocialNetworkService/FindUsersByOrganization?organization=XXX
		[HttpGet("FindUsersByOrganization")]
		public DataSet FindUsersByLocation(string organization)
		{
			return Objects.User.FindUsersByOrganization(organization);
		}

		// GET api/SocialNetworkService/GetFriends?RequestingUsername=XXX&RequestedUsername=XXX&VerificationToken=XXX
		[HttpGet("GetFriends")]
		public DataSet GetFriends(string RequestingUsername, string RequestedUsername, string VerificationToken)
		{
			return Objects.User.GetFriends(RequestedUsername);
		}

		// GET api/SocialNetworkService/GetFriendsList?RequestingUsername=XXX&RequestedUsername=XXX&VerificationToken=XXX
		[HttpGet("GetFriendsList")]
		public List<User> GetFriendsList(string RequestingUsername, string RequestedUsername, string VerificationToken)
		{
			return Objects.User.GetFriendsList(RequestedUsername);
		}


		// GET api/SocialNetworkService/GetProfile?RequestingUsername=XXX&RequestedUsername=XXX&VerificationToken=XXX
		[HttpGet("GetProfile")]
		public User GetProfile(string RequestingUsername, string RequestedUsername, string VerificationToken)
		{
			User user = new User();

			//Requested user's profile privacy settings
			DataSet settingsSet = Settings.LoadCurrentUserSettings(RequestedUsername);

			//Requested user's information
			DataSet informationSet = Objects.User.GetUserInfo(RequestedUsername);

			//Profile Info Privacy
			if (Convert.ToString(settingsSet.Tables[0].Rows[0]["ProfileInfo_Privacy"]) == "Public")
			{
				user.FirstName = Convert.ToString(informationSet.Tables[0].Rows[0]["FirstName"]);
				user.LastName = Convert.ToString(informationSet.Tables[0].Rows[0]["LastName"]);
				user.Address = Convert.ToString(informationSet.Tables[0].Rows[0]["StreetAddress"]);
				user.City = Convert.ToString(informationSet.Tables[0].Rows[0]["City"]);
				user.Org = Convert.ToString(informationSet.Tables[0].Rows[0]["Organization"]);

			}//You are friends
			else if (Convert.ToString(settingsSet.Tables[0].Rows[0]["ProfileInfo_Privacy"]) == "Friends" &&
					(Objects.User.IsFriend(RequestingUsername, RequestedUsername)))
			{
				user.FirstName = Convert.ToString(informationSet.Tables[0].Rows[0]["FirstName"]);
				user.LastName = Convert.ToString(informationSet.Tables[0].Rows[0]["LastName"]);
				user.Address = Convert.ToString(informationSet.Tables[0].Rows[0]["StreetAddress"]);
				user.City = Convert.ToString(informationSet.Tables[0].Rows[0]["City"]);
				user.Org = Convert.ToString(informationSet.Tables[0].Rows[0]["Organization"]);

			}//Not friends, so you can only see first and last name
			else if (Convert.ToString(settingsSet.Tables[0].Rows[0]["ProfileInfo_Privacy"]) == "Friends" &&
					(!Objects.User.IsFriend(RequestingUsername, RequestedUsername)))
			{
				user.FirstName = Convert.ToString(informationSet.Tables[0].Rows[0]["FirstName"]);
				user.LastName = Convert.ToString(informationSet.Tables[0].Rows[0]["LastName"]);

			}//You are not friends but if you are friends of friends, you can see all information
			else if (Convert.ToString(settingsSet.Tables[0].Rows[0]["ProfileInfo_Privacy"]) == "Friends Of Friends" &&
					(!Objects.User.IsFriend(RequestingUsername, RequestedUsername)))
			{
				//Check to see if the requested username is friends with someone who is friends with you
				if (Objects.User.IsFriendOfFriend(RequestingUsername, RequestedUsername))
				{
					user.FirstName = Convert.ToString(informationSet.Tables[0].Rows[0]["FirstName"]);
					user.LastName = Convert.ToString(informationSet.Tables[0].Rows[0]["LastName"]);
					user.Address = Convert.ToString(informationSet.Tables[0].Rows[0]["StreetAddress"]);
					user.City = Convert.ToString(informationSet.Tables[0].Rows[0]["City"]);
					user.Org = Convert.ToString(informationSet.Tables[0].Rows[0]["Organization"]);
				}
				else
				{
					user.FirstName = Convert.ToString(informationSet.Tables[0].Rows[0]["FirstName"]);
					user.LastName = Convert.ToString(informationSet.Tables[0].Rows[0]["LastName"]);
				}
			}

			//Contact Info Privacy
			if (Convert.ToString(settingsSet.Tables[0].Rows[0]["ContactInfo_Privacy"]) == "Public")
			{
				user.PhoneNum = Convert.ToString(informationSet.Tables[0].Rows[0]["FirstName"]);

			}//You are friends
			else if (Convert.ToString(settingsSet.Tables[0].Rows[0]["ContactInfo_Privacy"]) == "Friends" &&
					(Objects.User.IsFriend(RequestingUsername, RequestedUsername)))
			{
				user.PhoneNum = Convert.ToString(informationSet.Tables[0].Rows[0]["FirstName"]);

			}//Not friends 
			else if (Convert.ToString(settingsSet.Tables[0].Rows[0]["ContactInfo_Privacy"]) == "Friends" &&
					(!Objects.User.IsFriend(RequestingUsername, RequestedUsername)))
			{
				 //Do not add phone number to user obj

			}//You are not friends but if you are friends of friends, you can see phone #
			else if (Convert.ToString(settingsSet.Tables[0].Rows[0]["ContactInfo_Privacy"]) == "Friends Of Friends" &&
					(!Objects.User.IsFriend(RequestingUsername, RequestedUsername)))
			{
				//Check to see if the requested username is friends with someone who is friends with you
				if (Objects.User.IsFriendOfFriend(RequestingUsername, RequestedUsername))
				{
					user.PhoneNum = Convert.ToString(informationSet.Tables[0].Rows[0]["FirstName"]);
				}
				else
				{
					//Do not add phone number to user obj
				}
			}

			return user;
		}

		// GET api/SocialNetworkService/GetPhotos?RequestingUsername=XXX&RequestedUsername=XXX&VerificationToken=XXX
		[HttpGet("GetPhotos")]
		public User GetPhotos(string RequestingUsername, string RequestedUsername, string VerificationToken)
		{
			User user = new User();

			//Requested user's profile privacy settings
			DataSet settingsSet = Settings.LoadCurrentUserSettings(RequestedUsername);

			//Requested user's photos
			List<String> photoSet = Photos.userPhotoList(RequestedUsername);


			if (Convert.ToString(settingsSet.Tables[0].Rows[0]["Photo_Privacy"]) == "Public")
			{
				//All user's photos visible
				user.PhotoList = photoSet;

			}//You are friends
			else if (Convert.ToString(settingsSet.Tables[0].Rows[0]["Photo_Privacy"]) == "Friends" &&
					(Objects.User.IsFriend(RequestingUsername, RequestedUsername)))
			{
				//Add all photos to photoList
				user.PhotoList = photoSet;

			}//Not friends and requested user only shows photos to friends
			else if (Convert.ToString(settingsSet.Tables[0].Rows[0]["Photo_Privacy"]) == "Friends" &&
					(!Objects.User.IsFriend(RequestingUsername, RequestedUsername)))
			{
				//Only show profile photo
				user.PhotoList.Add(photoSet[0]);

			}//You are not friends 
			else if (Convert.ToString(settingsSet.Tables[0].Rows[0]["Photo_Privacy"]) == "Friends Of Friends" &&
					(!Objects.User.IsFriend(RequestingUsername, RequestedUsername)))
			{
				//Check to see if the requested username is friends with someone who is friends with you
				if (Objects.User.IsFriendOfFriend(RequestingUsername, RequestedUsername))
				{
					//Add all photos to photoList
					user.PhotoList = photoSet;
				}
				else
				{
					//Only show profile photo
					user.PhotoList.Add(photoSet[0]);
				}
			}
			return user;
		}
	}
}

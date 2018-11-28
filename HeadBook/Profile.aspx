<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="HeadBook.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
	<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
	<style>
		body {
			font-family: Arial, Helvetica, sans-serif;
		}
	</style>
</head>
<body>
	<form id="frmProfile" runat="server">
		<%-- Navbar Begins --%>
		<nav class="navbar navbar-expand-lg navbar-light bg-light">
			<a class="navbar-brand" href="#">HeadBook</a>
			<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
				<span class="navbar-toggler-icon"></span>
			</button>

			<div class="collapse navbar-collapse" id="navbarSupportedContent">
				<ul class="navbar-nav mr-auto">
					<li class="nav-item active">
						<a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
					</li>
					<li class="nav-item">
						<a class="nav-link" href="Settings.aspx">Settings <span class="sr-only"></span></a>
					</li>
					<li class="nav-item">
						<a class="nav-link" href="Profile.aspx">Profile<span class="sr-only"></span></a>
					</li>

				</ul>
				<div class="form-inline my-2 my-lg-0">
					<asp:Button ID="btnLogout" class="btn btn-outline-success my-2 my-sm-0" runat="server" Text="Logout" OnClick="btnLogout_Click"></asp:Button>
				</div>
			</div>
		</nav>
		<%-- Navbar End --%>

		<div class="container-fluid">
			<div class="row">
				<div class="col-lg-3" style="margin-left:3%">
					<asp:Image ID="imgProfilePhoto" ImageUrl="~/Photos/Profile-icon.png" Style="width: 200px; height: auto" runat="server" />
					<br />
					<asp:LinkButton ID="btnlkNewsFeed" runat="server">News Feed</asp:LinkButton>
					<br />
					<asp:LinkButton ID="btnlkWall" runat="server">Wall</asp:LinkButton>
					<br />
					<asp:LinkButton ID="btnlkPhotos" runat="server">Photos</asp:LinkButton>
					<br />
					<asp:LinkButton ID="btnlkFriends" runat="server">Friends</asp:LinkButton>
					<br />
					<div class="row">&nbsp</div>
					<div class="card" style="width: 75%; padding-left: 2%">
						<asp:Label ID="lblIntro" class="text-lg-left" Style="padding-top: 1%; font-size: 25px" runat="server" Text="Intro"></asp:Label>
						<div class="row">&nbsp</div>
						<asp:Label ID="lblJobTitle" class="text-sm-left" runat="server" Text="Occupation: "></asp:Label>
						<div class="row">&nbsp</div>
						<asp:Label ID="lblOrg" class="text-sm-left" runat="server" Text="Organization: "></asp:Label>
						<div class="row">&nbsp</div>
						<asp:Label ID="lblAddress" class="text-sm-left" runat="server" Text="Address: "></asp:Label>
						<div class="row">&nbsp</div>
						<asp:Label ID="lblPhone" class="text-sm-left" runat="server" Text="Phone: "></asp:Label>
					</div>

				</div>
				<div class="col-lg-5">
					<div class="panel rounded shadow" style="margin-top: 10%">
						<asp:TextBox id="txtPostArea" class="form-control input-lg no-border" Rows="2" TextMode="multiline" placeholder="What are you doing?..." runat="server" />
						<div class="panel-footer">
							<asp:Button class="btn btn-secondary" style="margin-top:1%; margin-left:1%; margin-bottom:1%" runat="server" Text="POST"></asp:Button>
							<ul class="nav nav-pills">
								<li><a href="#"><i class="fa fa-user"></i></a></li>
								<li><a href="#"><i class="fa fa-map-marker"></i></a></li>
								<li><a href="#"><i class="fa fa-camera"></i></a></li>
								<li><a href="#"><i class="fa fa-smile-o"></i></a></li>
							</ul>
							<!-- /.nav nav-pills -->
						</div>
						<!-- /.panel-footer -->
					</div>
					<!-- /.panel -->
				</div>
				<div class="col-lg-3" style="margin-left:3%">
					<div class="row text-center" style="margin-top:20%; margin-left: 20%">
						<asp:Label ID="lblFriendsOfFriends" runat="server" Text="People You May Know"></asp:Label>
					</div>
					<div class="card">

					</div>
				</div>
			</div>
		</div>
	</form>
</body>
</html>

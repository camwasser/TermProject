<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot_Password.aspx.cs" Inherits="HeadBook.Forgot_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
	<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
</head>
<body>
    <%-- Navbar Begins --%>
	<nav class="navbar navbar-expand-lg navbar-light bg-light">
		<a class="navbar-brand" href="#">HeadBook</a>
		<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
			<span class="navbar-toggler-icon"></span>
		</button>

		<div class="collapse navbar-collapse" id="navbarSupportedContent">
			<ul class="navbar-nav mr-auto">
				<li class="nav-item active">
					<a class="nav-link" href="Login_Register.aspx">Login <span class="sr-only">(current)</span></a>
				</li>
			</ul>
		</div>
	</nav>
	<%-- Navbar End --%>
    <form id="frmForgotPassword" runat="server">
		<div class="container">

			<h2 class="text-center">Password Recovery</h2>
            <div style="text-align: center; margin-right: auto; margin-left: auto">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </div>
			<div class="form-group row">
				<div class="offset-sm-2 col-lg-8">
					<asp:Label ID="lblSecQuestion1" runat="server" Text="Security Question #1: "></asp:Label>
					<asp:TextBox ID="txtSecAnswer1" class="form-control" runat="server" placeholder="Answer" required=""></asp:TextBox>
				</div>
			</div>
			<div class="form-group row">
				<div class="offset-sm-2 col-lg-8">
					<asp:Label ID="lblSecQuestion2" runat="server" Text="Security Question #2: "></asp:Label>
					<asp:TextBox ID="txtSecAnswer2" class="form-control" runat="server" placeholder="Answer" required=""></asp:TextBox>
				</div>
			</div>

			<div class="form-group row">
				<div class="offset-sm-2 col-lg-8">
					<asp:Label ID="lblSecQuestion3" runat="server" Text="Security Question #3: "></asp:Label>
					<asp:TextBox ID="txtSecAnswer3" class="form-control" runat="server" placeholder="Answer" required=""></asp:TextBox>
				</div>
			</div>
		</div>
		<div class="offset-sm-3 col-lg-6 center-block">
			<asp:Button ID="btnGetPassword" class="btn btn-dark form-control" runat="server" Text="Get Password" OnClick="btnGetPassword_Click" />
		</div>
	</form>
    <script>
        function valQuestions() {
            var A1 = document.getElementById("txtSecAnswer1").value;
            var A2 = document.getElementById("txtSecAnswer2").value;
            var A3 = document.getElementById("txtSecAnswer3").value;
            if (A1 == "") {
                alert("You must enter an answer fo question 1!");
                return false;
            }
            if (A2 == "") {
                alert("You must enter an answer fo question 2!");
                return false;
            }
            if (A3 == "") {
                alert("You must enter an answer fo question 3!");
                return false;
            }
            return true;
        }
    </script>
</body>
</html>

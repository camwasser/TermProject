<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Register.aspx.cs" Inherits="HeadBook.Login_Register" %>

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
                    <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                </li>
            </ul>
        </div>
    </nav>
    <%-- Navbar End --%>
    <form id="frmLoginRegister" runat="server">
        <div class="container">
            <div class="row" id="parent" style="left: 25%; margin-top: 5%; position: relative">
                <div class="col-md-6 col-12 card d-block border-0 py-2 text-center">
                    <a href="" class="btn btn-outline-secondary" data-toggle="collapse" data-target="#cardLogin" data-parent="#parent" onclick="loginDisplay()">Login</a>
                    <a href="" class="btn btn-outline-secondary" data-toggle="collapse" data-target="#cardRegister" data-parent="#parent" onclick="registerDisplay()">Register</a>
                    <div class="collapse show py-2" id="cardLogin">
                        <div class="card">
                            <div class="card-block">
                                <h2 class="text-xs-center">Login</h2>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:Label ID="lblLoginError" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputEmailForm" class="sr-only control-label">Email</label>
                                    <div class="offset-sm-2 col-sm-8">
                                        <asp:TextBox ID="txtUserName" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputPasswordForm" class="sr-only control-label">Password</label>
                                    <div class="offset-sm-2 col-sm-8">
                                        <asp:TextBox ID="txtPassword" class="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-sm-8">
                                        <div class="checkbox small">
                                            <asp:CheckBox ID="chkRememberMe" class="form-control" runat="server" Text="Remember Me" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-sm-8 pb-3 pt-2">
                                        <asp:Button ID="btnSignIn" runat="server" class="btn btn-secondary-outline btn-lg btn-block" Text="Sign In" onclick="btnSignIn_Click1" OnClientClick="return validateLogin()"></asp:Button>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-sm-8 pb-3 pt-2">
                                        <asp:Button ID="btnForgotPW" runat="server" class="btn btn-secondary-outline btn-lg btn-block" Text="Forgot Password?" OnClick="btnForgotPW_Click" OnClientClick="return validateForgotPW()"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="collapse py-2" id="cardRegister">
                        <div class="card">
                            <div class="card-block">
                                <h2 class="text-center">Register</h2>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:Label ID="lblError" Forecolor="Red" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtEmailRegister" class="form-control" runat="server" placeholder="email@example.com" TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtFirstName" class="form-control" runat="server" placeholder="First Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtLastName" class="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtAddress" class="form-control" runat="server" placeholder="Address"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtCity" class="form-control" runat="server" placeholder="City"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:DropDownList ID="ddlStates" class="form-control" runat="server">
                                            <asp:ListItem Value="AL">Alabama</asp:ListItem>
                                            <asp:ListItem Value="AK">Alaska</asp:ListItem>
                                            <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                                            <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                                            <asp:ListItem Value="CA">California</asp:ListItem>
                                            <asp:ListItem Value="CO">Colorado</asp:ListItem>
                                            <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                                            <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                                            <asp:ListItem Value="DE">Delaware</asp:ListItem>
                                            <asp:ListItem Value="FL">Florida</asp:ListItem>
                                            <asp:ListItem Value="GA">Georgia</asp:ListItem>
                                            <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                                            <asp:ListItem Value="ID">Idaho</asp:ListItem>
                                            <asp:ListItem Value="IL">Illinois</asp:ListItem>
                                            <asp:ListItem Value="IN">Indiana</asp:ListItem>
                                            <asp:ListItem Value="IA">Iowa</asp:ListItem>
                                            <asp:ListItem Value="KS">Kansas</asp:ListItem>
                                            <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                                            <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                                            <asp:ListItem Value="ME">Maine</asp:ListItem>
                                            <asp:ListItem Value="MD">Maryland</asp:ListItem>
                                            <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                                            <asp:ListItem Value="MI">Michigan</asp:ListItem>
                                            <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                                            <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                                            <asp:ListItem Value="MO">Missouri</asp:ListItem>
                                            <asp:ListItem Value="MT">Montana</asp:ListItem>
                                            <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                                            <asp:ListItem Value="NV">Nevada</asp:ListItem>
                                            <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                                            <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                                            <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                                            <asp:ListItem Value="NY">New York</asp:ListItem>
                                            <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                                            <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                                            <asp:ListItem Value="OH">Ohio</asp:ListItem>
                                            <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                                            <asp:ListItem Value="OR">Oregon</asp:ListItem>
                                            <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                                            <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                                            <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                                            <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                                            <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                                            <asp:ListItem Value="TX">Texas</asp:ListItem>
                                            <asp:ListItem Value="UT">Utah</asp:ListItem>
                                            <asp:ListItem Value="VT">Vermont</asp:ListItem>
                                            <asp:ListItem Value="VA">Virginia</asp:ListItem>
                                            <asp:ListItem Value="WA">Washington</asp:ListItem>
                                            <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                                            <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                                            <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtOrganization" class="form-control" runat="server" placeholder="School/Work etc..."></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtPhone" class="form-control" runat="server" placeholder="Phone" TextMode="Phone"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtPasswordRegister" class="form-control" runat="server" placeholder="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtSecQuestion1" class="form-control" runat="server" placeholder="Security Question #1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtSecAnswer1" class="form-control" runat="server" placeholder="Security Answer #1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtSecQuestion2" class="form-control" runat="server" placeholder="Security Question #2"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtSecAnswer2" class="form-control" runat="server" placeholder="Security Answer #2"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtSecQuestion3" class="form-control" runat="server" placeholder="Security Question #3"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-lg-8">
                                        <asp:TextBox ID="txtSecAnswer3" class="form-control" runat="server" placeholder="Security Answer #3"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="offset-sm-2 col-sm-8 pb-3 pt-2">
                                        <asp:Button ID="btnRegister" runat="server" class="btn btn-secondary-outline btn-lg btn-block" Text="Register" OnClick="btnRegister_Click" OnClientClick=" if (!valReg()) {return false;}" UseSubmitBehavior="false"></asp:Button>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script>
        function loginDisplay() {
            var x = document.getElementById("cardLogin");
            var y = document.getElementById("cardRegister");

            x.style.display = "block";
            y.style.display = "none";

        }

        function registerDisplay() {
            var x = document.getElementById("cardLogin");
            var y = document.getElementById("cardRegister");

            y.style.display = "block";
            x.style.display = "none";

        }

        // checks to see if user entered when forgotPW clicked
        function validateForgotPW() {
            var user = document.getElementById("txtUserName").value;
            if (user == "") {
                alert("You must enter a username!")
                return false;
            }
            return true;
        }

        // checks to see if user and pw entered on login click
        function validateLogin() {
            var user = document.getElementById("txtUserName").value;
            var pw = document.getElementById("txtPassword").value;
            if (user == "") {
                alert("You must enter a username!")
                return false;
            }
            if (pw == "") {
                alert("You must enter a password!")
                return false;
            }
            return true;
        }

        function valReg() {
            var user = document.getElementById("txtEmailRegister").value;
            var first = document.getElementById("txtFirstName").value;
            var last = document.getElementById("txtLastName").value;
            var address = document.getElementById("txtAddress").value;
            var city = document.getElementById("txtCity").value;
            var org = document.getElementById("txtOrganization").value;
            var phone = document.getElementById("txtPhone").value;
            var pw = document.getElementById("txtPasswordRegister").value;
            var Q1 = document.getElementById("txtSecQuestion1").value;
            var Q2 = document.getElementById("txtSecQuestion2").value;
            var Q3 = document.getElementById("txtSecQuestion3").value;
            var A1 = document.getElementById("txtSecAnswer1").value;
            var A2 = document.getElementById("txtSecAnswer2").value;
            var A3 = document.getElementById("txtSecAnswer3").value;
            if (user == "") {
                alert("Username/Email must not be blank");
                return false;
            }
            if (first == "") {
                alert("First name must not be blank");
                registerDisplay();
                return false;
                
            }
            if (!isNaN(first)) {
                alert("You must enter a valid first name");
                document.getElementById("txtFirstName").value("");
                registerDisplay();
                return false;
            }
            if (last == "") {
                alert("Last name must not be blank");
                return false;
            }
            if (!isNaN(last)) {
                alert("You must enter a valid last name");
                document.getElementById("txtLastName").value("");
                return false;
            }
            if (address == "") {
                alert("Address must not be blank");
                return false;
            }
            if (city == "") {
                alert("City must not be blank");
                return false;
            }
            if (!isNaN(city)) {
                alert("You must enter a valid city");
                document.getElementById("txtCity").value("");
                return false;
            }
            if (org == "") {
                alert("Organization must not be blank");
                return false;
            }
            if (phone == "") {
                alert("Phone number must not be blank");
                return false;
            }
            if (pw == "") {
                alert("Password must not be blank");
                return false;
            }
            if (Q1 == "") {
                alert("Security question #1 must not be blank");
                return false;
            }
            if (Q2 == "") {
                alert("Security question #2 must not be blank");
                return false;
            }
            if (Q3 == "") {
                alert("Security question #3 must not be blank");
                return false;
            }
            if (A1 == "") {
                alert("Security answer #1 must not be blank");
                return false;
            }
            if (A2 == "") {
                alert("Security answer #2 must not be blank");
                return false;
            }
            if (A3 == "") {
                alert("Security answer #3 must not be blank");
                return false;
            }
            return true;


        }
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="HeadBook.Settings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Settings</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
</head>
<body>

    <form id="frmSettings" runat="server">
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
                        <a class="nav-link" href="Profile.aspx">Profile <span class="sr-only"></span></a>
                    </li>
                </ul>
                <div class="form-inline my-2 my-lg-0">
                    <asp:Button ID="btnLogout" class="btn btn-outline-success my-2 my-sm-0" runat="server" Text="Logout" OnClick="btnLogout_Click"></asp:Button>
                </div>
            </div>
        </nav>
        <%-- Navbar End --%>

        <div class="container">
            <div class="collapse show py-2" id="loginSettings">
                <div class="card-block">
                    <h2 class="text-xs-center">Login Settings</h2>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblLoginSetting" runat="server" Text="Auto-Login"></asp:Label>
                    <asp:DropDownList ID="ddlAutoLogin" class="form-control" runat="server">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

			 <div class="collapse show py-2" id="emailSettings">
                <div class="card-block">
                    <h2 class="text-xs-center">Email Settings</h2>
                    <asp:Label ID="lblEmailSetting" runat="server" Text="Receive email notifications from HeadBook"></asp:Label>
                    <asp:DropDownList ID="ddlEmailSetting" class="form-control" runat="server">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="collapse show py-2" id="privacySettings">
                <div class="card-block">
                    <h2 class="text-xs-center">Privacy Settings</h2>
                    <asp:Label ID="lblPhotos" runat="server" Text="Photos"></asp:Label>
                    <asp:DropDownList ID="ddlPhotos" class="form-control" runat="server">
                        <asp:ListItem>Public</asp:ListItem>
                        <asp:ListItem>Only Friends</asp:ListItem>
                        <asp:ListItem>Friends of Friends</asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID="lblProfileInfo" runat="server" Text="Profile Information"></asp:Label>
                    <asp:DropDownList ID="ddlProfileInfo" class="form-control" runat="server">
                        <asp:ListItem>Public</asp:ListItem>
                        <asp:ListItem>Only Friends</asp:ListItem>
                        <asp:ListItem>Friends of Friends</asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID="lblContactInfo" runat="server" Text="Contact Information"></asp:Label>
                    <asp:DropDownList ID="ddlContactInfo" class="form-control" runat="server">
                        <asp:ListItem>Public</asp:ListItem>
                        <asp:ListItem>Only Friends</asp:ListItem>
                        <asp:ListItem>Friends of Friends</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="collapse show py-2" id="themeSettings">
                <div class="card-block">
                    <h2 class="text-xs-center">Themes</h2>
                    <asp:Label ID="lblFont" runat="server" Text="Font"></asp:Label>
                    <asp:DropDownList ID="ddlFont" class="form-control" runat="server">
                        <asp:ListItem>Arial</asp:ListItem>
                        <asp:ListItem>Helvetica</asp:ListItem>
                        <asp:ListItem>Times New Roman</asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID="lblBackgroundColor" runat="server" Text="Background Color"></asp:Label>
                    <asp:DropDownList ID="ddlBackgroundColor" class="form-control" runat="server">
                        <asp:ListItem>Grey</asp:ListItem>
                        <asp:ListItem>White</asp:ListItem>
                        <asp:ListItem>Navy</asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID="lblFontColors" runat="server" Text="Font Color"></asp:Label>
                    <asp:DropDownList ID="ddlFontColor" class="form-control" runat="server">
                        <asp:ListItem>Black</asp:ListItem>
                        <asp:ListItem>White</asp:ListItem>
                        <asp:ListItem>Grey</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-12 center-block">
                <asp:Button ID="btnSaveSettings" class="btn btn-dark form-control" runat="server" Text="Save Settings" OnClick="btnSaveSettings_Click" />
            </div>
            <div class="row">&nbsp</div>
        </div>
    </form>
</body>
</html>

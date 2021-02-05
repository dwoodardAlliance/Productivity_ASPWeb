<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Productivity_ASPWeb.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="width: 100%; text-align: center">
        <div style="width: 100%; text-align: center">
        </div>
        <br />
        <asp:Image ID="Image1" runat="server" />
        <br />
        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="Larger" Text="Productivity Login Page"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblUserName" runat="server" Font-Bold="True" Text="User Name:  " Width="100px"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server" BorderColor="#0000CC" BorderStyle="Solid" OnTextChanged="txtUserName_TextChanged" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword" runat="server" BorderStyle="None" Font-Bold="True" Text="Password:" Width="100px"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" BorderColor="#0000CC" BorderStyle="Solid" OnTextChanged="txtPassword_TextChanged" Width="200px"></asp:TextBox>
    </form>
</body>
</html>

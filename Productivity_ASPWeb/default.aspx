<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Productivity_ASPWeb._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="Larger" Text="Productivity Main Page"></asp:Label>
            <br />
            <asp:Panel ID="Panel1" runat="server">
                <asp:Button ID="btnServices" runat="server" Text="Services" Height="33px" OnClick="BtnServices_Click" Width="99px" />
                <br />
                <asp:Button ID="btnReports" runat="server" Height="33px" Text="Reports" Width="99px" />
                <br />
                <asp:Button ID="btnExit" runat="server" Height="33px" Text="Exit" Width="99px" />
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>

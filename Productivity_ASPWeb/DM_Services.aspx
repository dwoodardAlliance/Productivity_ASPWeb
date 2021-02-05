<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DM_Services.aspx.cs" Inherits="Productivity_ASPWeb.DM_Services" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <style>
                p.big   {
                        line-height: 1.8;
                        }
            </style>
            <asp:Panel ID="pnlTitle" runat="server">
                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#0000CC" Text="Services Maintenance"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlSearch" runat="server" CssClass="default.css" GroupingText="Search">
                <p class="big" aria-hidden="False">
                    <asp:Label ID="lblSrchEmployee_ID" runat="server" Text="Employee ID:" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtSrchEmployee_ID" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblSrchEmployee_Name" runat="server" Text="Employee Name:" Width="125px"></asp:Label>
                    <asp:TextBox ID="txtSrchEmployee_Name" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblSrchProgram" runat="server" Text="Program:" Width="70px"></asp:Label>
                    <asp:TextBox ID="txtSrchProgram" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="100px" />
                    <br />
                    <asp:Label ID="lblSrchService_Date" runat="server" Text="Service Date:" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtSrchService_Date" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSrchCPT_Code" runat="server" Text="CPT Code:" Width="80px"></asp:Label>
                    <asp:TextBox ID="txtSrchCPT_Code" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblSrchLocation" runat="server" Text="Location:" Width="70px"></asp:Label>
                    <asp:TextBox ID="txtSrchLocation" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" />
                </p>
            </asp:Panel>
            <asp:Panel ID="pnlDetails" runat="server" CssClass="default.css" GroupingText="Record Details">
                    <p class="big">
                    <asp:Label ID="lblEmployee_ID" runat="server" CssClass="default.css" Text="Employee ID:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtEmployee_ID" runat="server" CssClass="default"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblEmployee_Name" runat="server" Text="Employee Name:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtEmployee_Name" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCPT_Code" runat="server" Text="CPT Code:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtCPT_Code" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblCPT_Modifier" runat="server" Text="CPT Modifier:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtCPT_Modifier" runat="server"></asp:TextBox>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblClient_ID" runat="server" CssClass="default.css" Text="Client ID:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtClient_ID" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblClient_Name" runat="server" Text="Client Name:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtClient_Name" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblService_ID" runat="server" Text="Service ID:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtService_ID" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblService_Date" runat="server" Text="Service Date:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtService_Date" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblService_Type" runat="server" Text="Service Type:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtService_Type" runat="server"></asp:TextBox>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblProgram" runat="server" Text="Program:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtProgram" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLocation" runat="server" Text="Location:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblMerged_Units" runat="server" Text="Units:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtMerged_Units" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMerged_Duration" runat="server" Text="Duration:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtMerged_Duration" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;<br />&nbsp;&nbsp;
                    <asp:Label ID="lblCreatedBy" runat="server" Text="Created By:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtCreatedBy" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCreateDate" runat="server" Text="Create Date:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtCreateDate" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;<asp:Label ID="lblModifiedBy" runat="server" Text="Modified By:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtModifiedBy" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblModifiedDate" runat="server" Text="Modified Date:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtModifiedDate" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="chkbxRecordActive" runat="server" Text="Active?" />
                </p>
            </asp:Panel>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Panel ID="pnlGrid" runat="server" GroupingText="Services Table" Height="489px">
                <asp:GridView ID="dgvServices" runat="server">
                </asp:GridView>
                <asp:ScriptManager ID="ScriptManager2" runat="server">
                </asp:ScriptManager>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

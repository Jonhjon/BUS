<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_OperatorPort.aspx.cs" Inherits="復康巴士系統.OperatorPort" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            font-size: 60px;
            text-align: center;
            font-family: 標楷體;
            font-weight: 700;
            text-transform: none;
            color: #584DE6;
            font-variant: normal;
            z-index: 1;
            position: relative;
        }
        .auto-style3 {
            text-align: center;
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style3">
            <asp:Label ID="Label_SystemTitle" runat="server" CssClass="auto-style2" Text="復康巴士系統-營運商端"></asp:Label>
            <br />
            <asp:Panel ID="Panel2" runat="server" Height="312px">
                <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" style="margin-left: 0px">
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="分配" Text="分配" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" />
            </asp:Panel>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style3" Height="270px" Visible="False">
            <asp:Label ID="Label1" runat="server" Text="要分配的民眾預約編號 :"></asp:Label>
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="要分配給的司機 :"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="返回" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="確定" />
        </asp:Panel>
    </form>
</body>
</html>

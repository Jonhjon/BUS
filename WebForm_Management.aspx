<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_Management.aspx.cs" Inherits="復康巴士系統.WebForm2" %>

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
        }
    </style>
</head>
<body style="margin-top: 15px">
    <form id="form1" runat="server">
        <div class="auto-style3">
            <asp:Label ID="Label_SystemTitle" runat="server" CssClass="auto-style2" Text="復康巴士系統-後台"></asp:Label>
            <asp:Panel ID="Panel_Function" runat="server">
                <br />
                <asp:Label ID="Label11" runat="server" Text="請選擇功能"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button_people_Update" runat="server" OnClick="Button_people_Update_Click" Text="修改民眾資料" />
                <br />
                <br />
                <asp:Button ID="Button_Driver_Add" runat="server" OnClick="Button_Driver_Add_Click" Text="新增司機資料" />
                <br />
                <br />
                <asp:Button ID="Button_Driver_Update" runat="server" OnClick="Button_Driver_Update_Click" Text="修改司機資料" />
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" />
                <br />
            </asp:Panel>
            <asp:Panel ID="Panel_people_Update" runat="server" Visible="False">
                <asp:Label ID="Label16" runat="server" Text="請修改資料"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label__0" runat="server" Text="民眾帳號："></asp:Label>
                <asp:TextBox ID="TextBox_Update_UserID" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label_0" runat="server" Text="民眾密碼："></asp:Label>
                <asp:TextBox ID="TextBox_Update_UserPassword" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label17" runat="server" Text="民眾姓名："></asp:Label>
                <asp:TextBox ID="TextBox_Update_UserName" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label_p0" runat="server" Text="民眾電話："></asp:Label>
                <asp:TextBox ID="TextBox_Update_UserPhone" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label14" runat="server" Text="民眾郵件："></asp:Label>
                <asp:TextBox ID="TextBox_Update_UserEmail" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label15" runat="server" Text="民眾性別："></asp:Label>
                &nbsp;<asp:Label ID="Label_show_UpdateGender" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button_PeopleUpdate_OK" runat="server" OnClick="Button_PeopleUpdate_OK_Click" Text="修改" />
                <br />
                <asp:GridView ID="GridView3" runat="server" style="margin-left: 518px">
                </asp:GridView>
                <br />
                <asp:Button ID="Button_people_Update_Over" runat="server" OnClick="Button_people_Update_Over_Click" Text="執行其他功能" />
            </asp:Panel>
            <asp:Panel ID="Panel_Driver_Add" runat="server" Visible="False">
                <asp:Label ID="Label1" runat="server" Text="司機編號："></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label12" runat="server" Text="司機密碼："></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label13" runat="server" Text="司機年齡："></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Number"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button_DriverAdd_OK" runat="server" OnClick="Button_DriverAdd_OK_Click" Text="新增" style="height: 21px" />
                <br />
                <asp:GridView ID="GridView1" runat="server" style="margin-left: 583px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
                <br />
                <asp:Button ID="Button_Driver_Add_Over" runat="server" Text="執行其他功能" OnClick="Button_Driver_Add_Over_Click" />
            </asp:Panel>
            <asp:Panel ID="Panel_Driver_Update" runat="server" Visible="False">
                <asp:Label ID="Label18" runat="server" Text="請修改資料"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label22" runat="server" Text="司機編號："></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <asp:Label ID="Label23" runat="server" Text="司機密碼："></asp:Label>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label24" runat="server" Text="司機年齡："></asp:Label>
                <asp:TextBox ID="TextBox6" runat="server" TextMode="Number"></asp:TextBox>
                <br />
                <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin-left: 585px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br />
                <asp:Button ID="Button_DriverUpdate_OK" runat="server" OnClick="Button_UpdateOK_Click" Text="修改" />
                <br />
                <br />
                <asp:Button ID="Button_Driver_Update_Over" runat="server" Text="執行其他功能" OnClick="Button_Driver_Update_Over_Click" />
            </asp:Panel>
            <asp:Panel ID="Panel_check_driver" runat="server" Height="146px" Visible="False">
                <br />
                請輸入要更改的司機帳號:
                <asp:TextBox ID="TextBox_CheckHaveDriver" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="確認" />
            </asp:Panel>
            <asp:Panel ID="Panel_check_people" runat="server" Height="169px" Visible="False">
                請輸入要更改的民眾帳號 :
                <asp:TextBox ID="TextBox_checkHavePeople" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="check_have_People" runat="server" OnClick="check_have_People_Click" Text="確認" />
            </asp:Panel>
            <br />
        </div>
    </form>
</body>
</html>

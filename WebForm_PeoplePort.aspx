<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_PeoplePort.aspx.cs" Inherits="復康巴士系統.PeoplePort" %>

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
        .auto-style4 {
            position: relative;
            margin-bottom: 0px;
        }
        .auto-style5 {
            position: absolute;
            top: 529px;
            left: 522px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="auto-style3">
            <asp:Label ID="Label_SystemTitle" runat="server" CssClass="auto-style2" Text="復康巴士系統-民眾端"></asp:Label>
            </div>
            <div class="auto-style3">
                <asp:Panel ID="Panel_function" runat="server">
                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="請選擇功能"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="Button_Login" runat="server" OnClick="Button_Login_Click" Text="登入" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button_Register" runat="server" OnClick="Button_Register_Click" Text="註冊" />
                        <br />
                        <br />
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="返回" />
                        <br />
                    </div>
                </asp:Panel>
            </div>
            <asp:Panel ID="Panel_Login" runat="server" Visible="False">
                <div class="auto-style3">
                    <asp:Label ID="Label1" runat="server" Text="帳號："></asp:Label>
                    <asp:TextBox ID="TextBox_Ligin_UserID" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label" runat="server" Text="密碼："></asp:Label>
                    <asp:TextBox ID="TextBox_Ligin_UserPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Button_LoginOK" runat="server" OnClick="Button_LoginOK_Click" Text="OK" />
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel_Register" runat="server" Visible="False">
                <div class="auto-style3">
                    <asp:Label ID="Label__" runat="server" Text="帳號："></asp:Label>
                    <asp:TextBox ID="TextBox_Register_UserID" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label_" runat="server" Text="密碼："></asp:Label>
                    <asp:TextBox ID="TextBox_Register_UserPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="姓名："></asp:Label>
                    <asp:TextBox ID="TextBox_Register_UserName" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label_p" runat="server" Text="電話："></asp:Label>
                    <asp:TextBox ID="TextBox_Register_UserPhone" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="郵件："></asp:Label>
                    <asp:TextBox ID="TextBox_Register_UserEmail" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label9" runat="server" CssClass="auto-style5" style="position: relative" Text="性別："></asp:Label>
                    &nbsp;<asp:RadioButtonList ID="RadioButtonList_Register_UserGender" runat="server" CssClass="auto-style4" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <br />
                    <asp:Button ID="Button_RegisterOK" runat="server" OnClick="Button_RegisterOK_Click" Text="OK" />
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel_Function2" runat="server" Visible="False">
                <div class="auto-style3">
                    <asp:Label ID="Label12" runat="server" Text="請選擇功能"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="Button_Update_people" runat="server" OnClick="Button_Update_people_Click" Text="修改帳戶資料" />
                    <br />
                    <br />
                    <asp:Button ID="Button_Reserve" runat="server" OnClick="Button_Reserve_Click" Text="預約" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button_Search" runat="server" OnClick="Button_Search_Click" Text="查詢" />
                    <br />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="登出" />
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel_Update" runat="server" Visible="False">
                <div class="auto-style3">
                    <asp:Label ID="Label16" runat="server" Text="請修改資料"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label__0" runat="server" Text="帳號："></asp:Label>
                    <asp:TextBox ID="TextBox_Update_UserID" runat="server" Enabled="False"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label_0" runat="server" Text="密碼："></asp:Label>
                    <asp:TextBox ID="TextBox_Update_UserPassword" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="姓名："></asp:Label>
                    <asp:TextBox ID="TextBox_Update_UserName" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label_p0" runat="server" Text="電話："></asp:Label>
                    <asp:TextBox ID="TextBox_Update_UserPhone" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="郵件："></asp:Label>
                    <asp:TextBox ID="TextBox_Update_UserEmail" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="性別："></asp:Label>
                    &nbsp;<asp:Label ID="Label_show_UpdateGender" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="Button_UpdateOK" runat="server" OnClick="Button_UpdateOK_Click" Text="OK" />
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel_Reserve" runat="server" Visible="False">
                <div class="auto-style3">
                    <asp:Label ID="Label17" runat="server" Text="請填寫預約資料"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label20" runat="server" Text="性別："></asp:Label>
                    <asp:RadioButtonList ID="RadioButtonList_R_gender" runat="server" CssClass="auto-style4" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:Label ID="Label18" runat="server" Text="身分證："></asp:Label>
                    <asp:TextBox ID="TextBox_R_UID" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label19" runat="server" Text="出生年月日："></asp:Label>
                    <asp:TextBox ID="TextBox_R_Birth" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label26" runat="server" Text="身分別："></asp:Label>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0">身心障礙者</asp:ListItem>
                        <asp:ListItem Value="1">長照服務使用者</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:Label ID="Label21" runat="server" Text="乘車人數："></asp:Label>
                    <asp:TextBox ID="TextBox_R_PeopleNum" runat="server" TextMode="Number"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label22" runat="server" Text="預約時間："></asp:Label>
                    <asp:TextBox ID="TextBox_R_RSVTime" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label23" runat="server" Text="乘車地點："></asp:Label>
                    <asp:TextBox ID="TextBox_R_StartPlace" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label24" runat="server" Text="下車地點："></asp:Label>
                    <asp:TextBox ID="TextBox_R_EndPlace" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button_ReserveOK" runat="server" OnClick="Button_ReserveOK_Click" Text="OK" />
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel_Search" runat="server" Visible="False">
                <div class="auto-style3">
                    <asp:Label ID="Label25" runat="server" Text="目前預約資料："></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="GridView2" runat="server" style="margin-left: 0px">
                    </asp:GridView>
                    <br />
                    <br />
                    <asp:Button ID="Button_SearchOver" runat="server" OnClick="Button_SearchOver_Click" Text="執行其他功能" />
                    <br />
                </div>
            </asp:Panel>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>

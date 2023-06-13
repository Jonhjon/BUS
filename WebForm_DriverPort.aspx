<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_DriverPort.aspx.cs" Inherits="復康巴士系統.DriverPort" %>

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
    <link href="StyleSheet2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style3">
            <asp:Label ID="Label_SystemTitle" runat="server" CssClass="auto-style2" Text="復康巴士系統-司機端"></asp:Label>
            <br />
            <asp:Panel ID="Panel_Login_Driver" runat="server">
                <br />
                <asp:Label ID="Label1" runat="server" Text="帳號："></asp:Label>
                <asp:TextBox ID="TextBox_Ligin_DriverID" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label" runat="server" Text="密碼："></asp:Label>
                <asp:TextBox ID="TextBox_Ligin_DriverPassword" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button_LoginOK" runat="server" Text="OK" CausesValidation="False" OnClick="Button_LoginOK_Click" />
            </asp:Panel>
            <asp:Panel ID="Panel_Function" runat="server" Visible="False">
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登出" />
                <br />
                <br />
                &nbsp;<asp:Button ID="Button_ShowWork" runat="server" CausesValidation="False" OnClick="Button_ShowWork_Click" Text="勤務檢視" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_DrivingReport" runat="server" CausesValidation="False" OnClick="Button_DrivingReport_Click" Text="行駛回報" />
                <br />
            </asp:Panel>
            <asp:Panel ID="Panel_ShowWork" runat="server" Visible="False">
                <br />
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:Label ID="Label10" runat="server" Text="暫時沒有勤務" Visible="False"></asp:Label>
                <br />
                <br />
                <br />
                <asp:Button ID="Button_ShowWork_Over" runat="server" OnClick="Button_ShowWork_Over_Click" Text="執行其他功能" />
                <br />
            </asp:Panel>
            <asp:Panel ID="Panel_DrivingReport_1" runat="server" Visible="False">
                <asp:Label ID="Label8" runat="server" Text="預約編號："></asp:Label>
                <asp:TextBox ID="TextBox_R_Num" runat="server" Height="26px" TextMode="Number" Width="208px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_R_Num_InputOK" runat="server" OnClick="Button_R_Num_InputOK_Click" Text="回報" />
                <asp:RangeValidator ID="RangeValidator_R_Num" runat="server" CssClass="ErrorMessage" ErrorMessage="RangeValidator" Visible="False">預約編號錯誤</asp:RangeValidator>
                <br />
                <br />
                &nbsp;<asp:Button ID="Button_DrivingReport_Over1" runat="server" CausesValidation="False" OnClick="Button_DrivingReport_Over1_Click" Text="執行其他功能" />
                <br />
            </asp:Panel>
            <asp:Panel ID="Panel_DrivingReport_2" runat="server" Visible="False">
                <asp:Label ID="Label2" runat="server" Text="陪同人數："></asp:Label>
                <asp:TextBox ID="TextBox_AcpnyNum" runat="server" TextMode="Number"></asp:TextBox>
                <br />
                <asp:Label ID="Label9" runat="server" Text="總金額（依里程計算）："></asp:Label>
                <asp:TextBox ID="TextBox_CountMoney" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="補助金額："></asp:Label>
                <asp:TextBox ID="TextBox_SubsidyMoney" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <asp:Label ID="Label7" runat="server" Text="搭乘里程："></asp:Label>
                <asp:TextBox ID="TextBox_Mileage" runat="server" OnTextChanged="TextBox_Mileage_TextChanged"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="應收金額（總金額-補助）："></asp:Label>
                <asp:TextBox ID="TextBox_FinalMoney" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button_MoneyCount" runat="server" CausesValidation="False" OnClick="Button_MoneyCount_Click" Text="上傳" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_DrivingReport_Over2" runat="server" OnClick="Button_DrivingReport_Over2_Click" Text="執行其他功能" />
            </asp:Panel>
            <br />
            <br />
        </div>
    </form>
</body>
</html>

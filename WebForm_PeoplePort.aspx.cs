using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 復康巴士系統
{
    public partial class PeoplePort : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=cm3023203;database=recoverybus_2;port=3306");
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel_Login.Visible = false;
            Panel_Register.Visible = false;
            Panel_Function2.Visible = false;
            Panel_Update.Visible = false;
            Panel_Reserve.Visible = false;
            Panel_Search.Visible = false;
        }

        protected void Button_Login_Click(object sender, EventArgs e)
        {
            Panel_Login.Visible = true;
            Panel_Register.Visible = false;
        }

        protected void Button_Register_Click(object sender, EventArgs e)
        {
            Panel_Login.Visible = false;
            Panel_Register.Visible = true;
        }



        protected void Button_LoginOK_Click(object sender, EventArgs e)
        {
            //比對資料庫帳號
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Account_User WHERE AU_ID = @Id AND AU_Password = @Passwor", conn);
            cmd.Parameters.AddWithValue("@Id", TextBox_Ligin_UserID.Text);
            cmd.Parameters.AddWithValue("@Passwor", TextBox_Ligin_UserPassword.Text);
            if (cmd.ExecuteReader().HasRows)
            {
                Response.Write("<script type='text/javascript'>alert('帳號登入成功!!!')</script>");
                Panel_function.Visible = false;
                Panel_Login.Visible = false;
                Panel_Function2.Visible = true;
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('沒有此帳號，或是帳號、密碼輸入錯誤!!!')</script>");
            }
            cmd.Dispose();
            conn.Close();
            //登入成功 -> 切換至下一階段

        }

        protected void Button_RegisterOK_Click(object sender, EventArgs e)
        {
            conn.Open();
            //帳號新增置資料庫
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Account_User WHERE AU_ID = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", TextBox_Register_UserID.Text);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            conn.Close();
            cmd.Dispose();
            if (dataReader.HasRows)
            {
                Response.Write("<script type='text/javascript'>alert('已有此帳號，請再輸入一次!!!')</script>");
            }
            else
            {
                conn.Open();
                cmd = new MySqlCommand("INSERT INTO Account_User (AU_ID, AU_Password, AU_Name, AU_Gender, AU_Phone, AU_Mail) VALUES (@Id, @Password, @Name, @Gender, @Phone, @Mail)", conn);
                cmd.Parameters.AddWithValue("@Id", TextBox_Register_UserID.Text);
                cmd.Parameters.AddWithValue("@Password", TextBox_Register_UserPassword.Text);
                cmd.Parameters.AddWithValue("@Name", TextBox_Register_UserName.Text);
                cmd.Parameters.AddWithValue("@Gender", RadioButtonList_Register_UserGender.SelectedItem.Text);
                // cmd.Parameters.AddWithValue("@Relation", TextBox_Register_UserID);
                cmd.Parameters.AddWithValue("@Phone", TextBox_Register_UserPhone.Text);
                cmd.Parameters.AddWithValue("@Mail", TextBox_Register_UserEmail.Text);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("SELECT * FROM Account_User", conn);
                cmd.Parameters.AddWithValue("@Id", TextBox_Register_UserID.Text);

                GridView2.DataSource = cmd.ExecuteReader();
                GridView2.DataBind();
                Response.Write("<script type='text/javascript'>alert('帳號註冊成功!!!')</script>");
                //註冊成功 -> 切換至登入
                Panel_Register.Visible = false;
                Panel_function.Visible = true;
            }
            conn.Close();
        }

        protected void Button_UpdateOK_Click(object sender, EventArgs e)
        {
            //修改至資料庫
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE Account_User SET AU_Name=@Name,AU_Password=@Password,AU_Phone=@Phone,AU_Mail=@Mail WHERE AU_ID = @Id", conn);
            cmd.Parameters.AddWithValue("@Name", TextBox_Update_UserName.Text);
            cmd.Parameters.AddWithValue("@Password", TextBox_Update_UserPassword.Text);
            cmd.Parameters.AddWithValue("@Phone", TextBox_Update_UserPhone.Text);
            cmd.Parameters.AddWithValue("@Mail", TextBox_Update_UserEmail.Text);
            cmd.Parameters.AddWithValue("@Id", TextBox_Ligin_UserID.Text);
            cmd.ExecuteNonQuery();

            cmd = new MySqlCommand("SELECT * FROM Account_User WHERE AU_ID = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", TextBox_Ligin_UserID.Text);
            GridView2.DataSource = cmd.ExecuteReader();
            GridView2.DataBind();
            //切換回 Panel_Function2
            Panel_Update.Visible = false;
            Panel_Function2.Visible = true;
            conn.Close();
            cmd.Dispose();
        }

        protected void Button_Update_people_Click(object sender, EventArgs e)
        {
            Panel_Function2.Visible = false;
            Panel_Update.Visible = true;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Account_User WHERE  AU_ID = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", TextBox_Ligin_UserID.Text);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            TextBox_Update_UserID.Text = dr["AU_ID"].ToString();
            TextBox_Update_UserPassword.Text = dr["AU_Password"].ToString();
            TextBox_Update_UserName.Text = dr["AU_Name"].ToString();
            TextBox_Update_UserPhone.Text = dr["AU_Phone"].ToString();
            TextBox_Update_UserEmail.Text = dr["AU_Mail"].ToString();
            Label_show_UpdateGender.Text = dr["AU_Gender"].ToString();
            //Panel_Update 資料預先綁定原始資料
            cmd.Dispose();
            conn.Close();
        }

        protected void Button_Reserve_Click(object sender, EventArgs e)
        {
            Panel_Function2.Visible = false;
            Panel_Reserve.Visible = true;
        }

        protected void Button_Search_Click(object sender, EventArgs e)
        {
            //Panel_Function2.Visible = false;
            //Panel_Reserve.Visible = true;

            //顯示目前預約資料
            Panel_Search.Visible = true;
            Panel_Function2.Visible = false;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Reserve_User WHERE R_U_User = @User", conn);
            cmd.Parameters.AddWithValue("@User", TextBox_Ligin_UserID.Text);
            GridView2.DataSource = cmd.ExecuteReader();
            GridView2.DataBind();
            cmd.Dispose();
            conn.Close();
        }

        protected void Button_ReserveOK_Click(object sender, EventArgs e)
        {
            //新增預約資料至資料庫
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Reserve_User (R_UID, R_Birth, R_Gender, R_peopleNum, R_RSVTime, R_StartPlace, R_EndPlace, R_U_User,R_type)\r\nVALUES (@UID, @Birth, @Gender, @People_num, @RSVTime, @StartPlace, @EndPlace, @User,@type)\r\n", conn);
            cmd.Parameters.AddWithValue("@UID", TextBox_R_UID.Text);
            cmd.Parameters.AddWithValue("@Birth", TextBox_R_Birth.Text);
            cmd.Parameters.AddWithValue("@Gender", RadioButtonList_R_gender.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@People_num", TextBox_R_PeopleNum.Text);
            cmd.Parameters.AddWithValue("@RSVTime", TextBox_R_RSVTime.Text);
            cmd.Parameters.AddWithValue("@StartPlace", TextBox_R_StartPlace.Text);
            cmd.Parameters.AddWithValue("@EndPlace", TextBox_R_EndPlace.Text);
            cmd.Parameters.AddWithValue("@User", TextBox_Ligin_UserID.Text);
            cmd.Parameters.AddWithValue("@type", RadioButtonList1.SelectedItem.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            //切換回 Panel_Function2
            Panel_Reserve.Visible = false;
            Panel_Function2.Visible = true;
        }

        protected void Button_SearchOver_Click(object sender, EventArgs e)
        {
            Panel_Search.Visible=false;
            Panel_Function2.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel_Function2.Visible=true;
            Panel_Reserve.Visible=false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel_Function2.Visible=false;
            Panel_function.Visible=true;
            TextBox_Ligin_UserID.Text = "";
            TextBox_Ligin_UserPassword.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm_Main.aspx", true);
        }
    }
}
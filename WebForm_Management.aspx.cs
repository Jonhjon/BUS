using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 復康巴士系統
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=cm3023203;database=recoverybus_2;port=3306");

        protected void Page_Load(object sender, EventArgs e)
        {
           // Panel_Function.Visible = true;
           
        }

        protected void Button_people_Update_Over_Click(object sender, EventArgs e)
        {
            Panel_Function.Visible = true;
            Panel_people_Update.Visible = false;
        }

        protected void Button_people_Update_Click(object sender, EventArgs e)
        {
            //conn.Open();
            //MySqlCommand cmd = new MySqlCommand("SELECT * FROM Account_User WHERE AU_ID=@Id", conn);
            //cmd.Parameters.AddWithValue()

            Panel_Function.Visible = false;
            //Panel_people_Update.Visible = true;
            Panel_check_people.Visible= true;
        }

        protected void Button_Driver_Add_Click(object sender, EventArgs e)
        {
            Panel_Function.Visible = false;
            Panel_Driver_Add.Visible = true;
        }

        protected void Button_Driver_Update_Click(object sender, EventArgs e)
        {
            Panel_Function.Visible = false;
           // Panel_Driver_Update.Visible = true;
            Panel_check_driver.Visible = true;
        }

        protected void Button_DriverAdd_OK_Click(object sender, EventArgs e)
        {
            //新增司機資料
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Driver WHERE D_Id=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", TextBox1.Text);
            MySqlDataReader dr = cmd.ExecuteReader();
            cmd.Dispose();
            if (dr.HasRows)
            {
                Response.Write("<script type='text/javascript'>alert('重複註冊!!!')</script>");
            }
            else
            {
                dr.Close();
                conn.Close();
                conn.Open();
                cmd = new MySqlCommand("INSERT INTO Driver (D_Id, D_pass, D_age) VALUES (@ID, @Pass, @age)", conn);
                cmd.Parameters.AddWithValue("@ID", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Pass", TextBox2.Text);
                cmd.Parameters.AddWithValue("@age", TextBox3.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Dispose();
                conn.Open();
                cmd = new MySqlCommand("SELECT * FROM Driver WHERE D_Id=@ID AND D_pass=@Pass", conn);
                cmd.Parameters.AddWithValue("@ID", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Pass", TextBox2.Text);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                    Response.Write("<script type='text/javascript'>alert('司機註冊註冊成功!!!')</script>");
                    dr.Close();

                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('司機註冊註冊失敗!!!')</script>");
                    dr.Close();
                }
            }
            conn.Close();
            cmd.Dispose();
        }

        protected void Button_PeopleUpdate_OK_Click(object sender, EventArgs e)
        {
            //修改民眾資料
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE Account_User SET AU_Password=@pass,AU_Name=@name,AU_Phone=@phone,AU_Mail=@email WHERE AU_ID=@Id", conn);
            cmd.Parameters.AddWithValue("@pass", TextBox_Update_UserPassword.Text);
            cmd.Parameters.AddWithValue("@name", TextBox_Update_UserName.Text);
            cmd.Parameters.AddWithValue("@phone", TextBox_Update_UserPhone.Text);
            cmd.Parameters.AddWithValue("@email", TextBox_Update_UserEmail.Text);
            cmd.Parameters.AddWithValue("@Id", TextBox_Update_UserID.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Open();

            cmd = new MySqlCommand("SELECT * FROM Account_User WHERE AU_ID=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", TextBox_Update_UserID.Text);
            MySqlDataReader dr= cmd.ExecuteReader();
            if (dr.HasRows)
            {
                GridView3.DataSource= dr;
                GridView3.DataBind();
            }
            conn.Close();
            cmd.Dispose();
        }

        protected void Button_UpdateOK_Click(object sender, EventArgs e)
        {
            //修改司機資料
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE Driver SET D_pass=@pass,D_age=@age WHERE D_Id=@Id", conn);
            cmd.Parameters.AddWithValue("@pass", TextBox5.Text);
            cmd.Parameters.AddWithValue("@age", TextBox6.Text);
            cmd.Parameters.AddWithValue("@Id", TextBox4.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM Driver WHERE D_Id=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", TextBox_CheckHaveDriver.Text);
            GridView2.DataSource = cmd.ExecuteReader();
            GridView2.DataBind();
            cmd.Dispose();
            conn.Close();
        }

        protected void Button_Driver_Add_Over_Click(object sender, EventArgs e)
        {
            Panel_Function.Visible = true;
            Panel_Driver_Add.Visible=false;
        }

        protected void Button_Driver_Update_Over_Click(object sender, EventArgs e)
        {
            Panel_Function.Visible = true;
            Panel_Driver_Update.Visible=false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Driver WHERE D_Id=@ID",conn);
            cmd.Parameters.AddWithValue("@ID", TextBox_CheckHaveDriver.Text);
            MySqlDataReader dr= cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {   
                TextBox4.Text = dr["D_Id"].ToString();
                TextBox5.Text = dr["D_pass"].ToString();
                TextBox6.Text = dr["D_age"].ToString();
                Panel_Driver_Update.Visible = true;
                Panel_check_driver.Visible = false;
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('沒有此司機!!!')</script>");
            }
            conn.Close();
        }

        protected void check_have_People_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Account_User WHERE AU_ID=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", TextBox_checkHavePeople.Text);
            MySqlDataReader dr= cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                TextBox_Update_UserID.Text = dr["AU_ID"].ToString();
                TextBox_Update_UserName.Text = dr["AU_Name"].ToString();
                TextBox_Update_UserPassword.Text = dr["AU_Password"].ToString();
                TextBox_Update_UserPhone.Text = dr["AU_Phone"].ToString();
                TextBox_Update_UserEmail.Text = dr["AU_Mail"].ToString();
                Label_show_UpdateGender.Text = dr["AU_Gender"].ToString();
                Panel_check_people.Visible = false;
                Panel_people_Update.Visible = true;
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('沒有此民眾!!!')</script>");
            }
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm_Main.aspx", true);
        }
    }
}
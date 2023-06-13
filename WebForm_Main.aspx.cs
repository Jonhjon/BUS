//using ;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 復康巴士系統
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=cm3023203;database=recoverybus_2;port=3306");
        //using (MySqlConnection connection = new MySqlConnection(connectionString))
        //{
        //    // 在這裡執行與資料庫相關的操作
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        

        protected void Button_Operator_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm_OperatorPort.aspx", true);
        }

        protected void Button_Driver_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm_DriverPort.aspx", true);
        }
        

        protected void Button_ManagementBackground_Click(object sender, EventArgs e)
        {
            Panel1.Visible= true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand cmd=new MySqlCommand("SELECT * FROM Manager WHERE Ma_account=@USser AND Ma_password=@Password", conn);
            cmd.Parameters.AddWithValue("@USser", Manger_logi_User.Text);
            cmd.Parameters.AddWithValue("@Password", Manger_logi_Password.Text);
            if (cmd.ExecuteReader().HasRows)
            {
                Response.Write("<script type='text/javascript'>alert('管理員帳號登入成功!!!')</script>");
                Server.Transfer("WebForm_Management.aspx", true);
                conn.Close();
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('管理員帳號登入失敗!!!')</script>");

            }
            conn.Close();
            cmd.Dispose();
        }

        protected void Button_People_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm_PeoplePort.aspx", true);
        }
    }
}
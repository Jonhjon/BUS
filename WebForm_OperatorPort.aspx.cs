using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 復康巴士系統
{
    public partial class OperatorPort : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=cm3023203;database=recoverybus_2;port=3306");

        protected void Page_Load(object sender, EventArgs e)
        {
            //分配一筆預約給某一位司機
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Reserve_User WHERE R_User IS NULL", conn);
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            conn.Close();
            cmd.Dispose();

            conn.Open();
            cmd = new MySqlCommand("SELECT DISTINCT D_Id FROM Driver", conn);
            MySqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr["D_Id"].ToString());
            }
            cmd.Dispose();
            conn.Close();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "分配")
            {
                Panel2.Visible= false;
                Panel1.Visible= true;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView1.Rows[index];
                string productName = selectedRow.Cells[1].Text;
                Label2.Text= productName;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Reserve_User WHERE R_Num=@NUM", conn);
                cmd.Parameters.AddWithValue("@NUM", productName);
                GridView2.DataSource= cmd.ExecuteReader();
                GridView2.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm_Main.aspx", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Panel1.Visible= false;
            Panel2.Visible= true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE Reserve_User SET R_User=@Driver WHERE R_Num=@NUM", conn);
            cmd.Parameters.AddWithValue("@NUM", Label2.Text);
            cmd.Parameters.AddWithValue("@Driver", DropDownList1.SelectedItem.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            Page_Load(sender, e);
            Panel1.Visible=false;
            Panel2.Visible= true;
        }
    }
}
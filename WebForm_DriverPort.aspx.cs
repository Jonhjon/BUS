using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 復康巴士系統
{
    public partial class DriverPort : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=cm3023203;database=recoverybus_2;port=3306");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button_LoginOK_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Driver WHERE D_Id=@Id AND D_pass=@pass", conn);
            cmd.Parameters.AddWithValue("@Id", TextBox_Ligin_DriverID.Text);
            cmd.Parameters.AddWithValue("@pass", TextBox_Ligin_DriverPassword.Text);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Response.Write("<script type='text/javascript'>alert('司機登入成功!!!')</script>");
                Panel_Login_Driver.Visible = false;
                Panel_Function.Visible = true;
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('司機登入失敗!!!')</script>");
            }
            cmd.Dispose();
            conn.Close();
        }

        protected void Button_ShowWork_Click(object sender, EventArgs e)
        {
            Panel_Function.Visible = false;
            Panel_ShowWork.Visible = true;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Reserve_User WHERE R_User=@user AND R_Utype IS NULL ORDER BY R_RSVTime ASC", conn);
            cmd.Parameters.AddWithValue("@user", TextBox_Ligin_DriverID.Text);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                GridView1.DataSource = dr;
                GridView1.DataBind();
            }
            else
            {
                Label10.Visible = true;
            }
            cmd.Dispose();
            conn.Close();

            //資料庫顯示分配到勤務
        }

        protected void Button_DrivingReport_Click(object sender, EventArgs e)
        {
            Panel_Function.Visible = false;
            Panel_DrivingReport_1.Visible = true;
        }

        protected void Button_ShowWork_Over_Click(object sender, EventArgs e)
        {
            Panel_ShowWork.Visible = false;
            Panel_Function.Visible = true;
        }

        protected void Button_DrivingReport_Over1_Click(object sender, EventArgs e)
        {
            Panel_DrivingReport_1.Visible = false;
            Panel_Function.Visible = true;
        }

        protected void Button_MoneyCount_Click(object sender, EventArgs e)
        {
            //int finalMoney = 0;
            //if (int.Parse(TextBox_AcpnyNum.Text) >= 1 && TextBox_Mileage.Text != "")
            //{
            //    //計算總金額 = 里程數*10*人數（1km 10元）政府每公里 每人補助3元
            //    TextBox_CountMoney.Text = (float.Parse(TextBox_Mileage.Text) * 10 * int.Parse(TextBox_AcpnyNum.Text)).ToString();

            //    //計算最後金額
            //    finalMoney = int.Parse(TextBox_CountMoney.Text) - int.Parse(TextBox_SubsidyMoney.Text);
            //    if (finalMoney > 0)
            //    {
            //        TextBox_FinalMoney.Text = finalMoney.ToString();
            //    }
            //    else
            //    {
            //        TextBox_FinalMoney.Text = "0";

            //    }
            //}
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Car_collection_report (CCR_Id, CCR_Accompanying_people, CCR_Amount_receivable, CCR_Subsidy_amount, CCR_lump_sum, CCR_total_mileage)\r\nVALUES (@trip, @people, @total_money, @suport_money, @money, @mileage);\r\n", conn);
            cmd.Parameters.AddWithValue("@trip", TextBox_R_Num.Text);
            cmd.Parameters.AddWithValue("@people", TextBox_AcpnyNum.Text);
            cmd.Parameters.AddWithValue("@total_money", TextBox_CountMoney.Text);
            cmd.Parameters.AddWithValue("@suport_money", TextBox_SubsidyMoney.Text);
            cmd.Parameters.AddWithValue("@money", TextBox_FinalMoney.Text);
            cmd.Parameters.AddWithValue("@mileage", TextBox_Mileage.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new MySqlCommand("UPDATE Reserve_User SET R_Utype = @type WHERE R_Num=@num", conn);
            cmd.Parameters.AddWithValue("@type", '1');
            cmd.Parameters.AddWithValue("@num", TextBox_R_Num.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new MySqlCommand("SELECT * FROM Car_collection_report WHERE CCR_Id=@trip", conn);
            cmd.Parameters.AddWithValue("@trip", TextBox_R_Num.Text);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Response.Write("<script type='text/javascript'>alert('回報成功!!!')</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('回報失敗!!!')</script>");
            }
            cmd.Dispose();
            conn.Close();
        }

        protected void Button_DrivingReport_Over2_Click(object sender, EventArgs e)
        {
            Panel_DrivingReport_2.Visible = false;
            Panel_Function.Visible = true;
        }

        protected void Button_R_Num_InputOK_Click(object sender, EventArgs e)
        {
            //驗證預約編號資料
            /*
               if (預約編號存在)
               {
                   Panel_DrivingReport_2.Visible = true;
                   Panel_DrivingReport_1.Visible = false;

                   //顯示補助金額
                   *//* if (預約乘客身分別為 身心障礙者){
                        TextBox_SubsidyMoney.Text = "300";
                    }
                        else  //預約乘客身分別為 長照服務使用者
                    {
                        TextBox_SubsidyMoney.Text = "150";
                    }
                   *//*
               }
               else
               {
                   RangeValidator_R_Num.Visible = true;
               }
            */
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM  Reserve_User WHERE R_Num=@num AND R_User = @Driver AND R_Utype IS NULL", conn);
            cmd.Parameters.AddWithValue("@num", TextBox_R_Num.Text);
            cmd.Parameters.AddWithValue("@Driver", TextBox_Ligin_DriverID.Text);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                TextBox_AcpnyNum.Text = dr["R_peopleNum"].ToString();
                Panel_DrivingReport_2.Visible = true;
                Panel_DrivingReport_1.Visible = false;
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('編號輸入失敗!!!')</script>");
            }
            cmd.Dispose();
            conn.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel_Function.Visible = false;
            Panel_Login_Driver.Visible = true;
            TextBox_Ligin_DriverID.Text = "";
        }

        protected void TextBox_Mileage_TextChanged(object sender, EventArgs e)
        {
            int finalMoney = 0;
            if (int.Parse(TextBox_AcpnyNum.Text) >= 1 && TextBox_Mileage.Text != "")
            {
                //計算總金額 = 里程數*10*人數（1km 10元）政府每公里 每人補助3元
                float total_km_money = float.Parse(TextBox_AcpnyNum.Text) * 10 * float.Parse(TextBox_Mileage.Text);
                TextBox_CountMoney.Text = total_km_money.ToString();
                TextBox_SubsidyMoney.Text = (float.Parse(TextBox_AcpnyNum.Text) * 3 * float.Parse(TextBox_Mileage.Text)).ToString();

                //TextBox_CountMoney.Text = (float.Parse(TextBox_Mileage.Text) * 10 * int.Parse(TextBox_AcpnyNum.Text)).ToString();

                //計算最後金額
                finalMoney = int.Parse(TextBox_CountMoney.Text) - int.Parse(TextBox_SubsidyMoney.Text);
                if (finalMoney > 0)
                {
                    TextBox_FinalMoney.Text = finalMoney.ToString();
                }
                else
                {
                    TextBox_FinalMoney.Text = "0";

                }
            }
        }
    }
}
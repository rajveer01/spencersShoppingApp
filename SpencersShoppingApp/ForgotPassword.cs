using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SpencersShoppingApp
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }
        static string Operation_type;
        public void alert(string msg, string ufi = "0", string lblheadt = "Oops!!!")
        {
            PnlAlert.Location = new Point(440, 220);
            LblAlertMsg.Text = msg;
            PnlAlert.Visible = true;
            Operation_type = ufi;
            Lblhead.Text = lblheadt;
            Lblhead.Location = new Point((560 - Lblhead.Width) / 2, 17);
            LblAlertMsg.Location = new Point((560 - LblAlertMsg.Width) / 2, 149);
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            string cs = "server = Jarvis\\sqlexpress; Database = spencers; Integrated Security = true;";
            string command = "SELECT * FROM sequ";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CBSecQu.Items.Insert(Convert.ToInt32(dr["id"].ToString()), dr["question"]);
            }
            dr.Close();
            conn.Close();
        }

        private void CBSecQu_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtAns.Focus();
        }

        private void TxtId_Enter(object sender, EventArgs e)
        {
            if(TxtId.Text=="Enter You ID Here Please")
            {
                TxtId.Text = "";
            }
        }

        private void TxtAns_Enter(object sender, EventArgs e)
        {
            if (TxtAns.Text == "Enter Your Answer Here Please")
            {
                TxtAns.Text = "";
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
            p.Close();
        }

        private void BtnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnGetPwd_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "" || TxtAns.Text == "" || CBSecQu.SelectedIndex == -1 || TxtId.Text == "Enter You ID Here Please" || TxtAns.Text == "Enter Your Answer Here Please")
            {
                alert("Please Enter The information.", "no login");
            }
            else
            {
                string cs = "server = Jarvis\\sqlexpress; Database = spencers; Integrated Security = true;";
                string command = "SELECT * FROM users WHERE id = '" + TxtId.Text + "'";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                SqlCommand cmd = new SqlCommand(command, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    i++;
                    if (dr["qno"].ToString() == CBSecQu.SelectedIndex.ToString() && dr["ans2q"].ToString() == TxtAns.Text)
                    {
                        alert(dr["pwd"].ToString(), "0", "Your Password is : ");
                    }
                    else
                    {
                        dr.Close();
                        command = "UPDATE users SET active='false' WHERE id = '" + TxtId.Text + "'";
                        cmd = new SqlCommand(command, conn);
                        cmd.ExecuteNonQuery();
                        alert("You are Blocked Now. Contact to admin Now.", "0", "Wrong Answer");
                        break;
                    }
                }
                if (i == 0)
                    alert("User Not Found","no login");
            }
        }

        private void BtnAlert_Click(object sender, EventArgs e)
        {
            if (Operation_type == "no login")
            {
                PnlAlert.Visible = false;
            }
            else
            {
                this.Hide();
                Login lg = new Login();
                lg.Show();
            }
        }

        private void TxtId_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TxtId.Text, "  ^ [0-9]"))
            {
                TxtId.Text = "";
            }
        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}

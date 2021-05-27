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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        static string Operation_type;
        public void alert(string msg, string ufi = "0" )
        {
            PnlAlert.Location = new Point(440, 220);
            LblAlertMsg.Text = msg;
            PnlAlert.Visible = true;
            Operation_type = ufi;

           // Lblhead.Location = new Point((560 - Lblhead.Width) / 2, 17);
            LblAlertMsg.Location = new Point((560 - LblAlertMsg.Width) / 2, 149);
        }

        private void TxtId_Enter(object sender, EventArgs e)
        {
            if (TxtId.Text == "Enter You ID Here Please")
                TxtId.Text = "";
        }

        private void TxtPwd_Enter(object sender, EventArgs e)
        {
            if (TxtPwd.Text == "Enter You PWD Here Please")
            {
                TxtPwd.UseSystemPasswordChar = true;
                TxtPwd.Text = "";
                PBPwdShow.BackColor = Color.FromArgb(0);

            }
        }

        private void PBPwdShow_Click(object sender, EventArgs e)
        {
            if (TxtPwd.UseSystemPasswordChar)
            {
                PBPwdShow.BackColor = Color.Gray;
                TxtPwd.UseSystemPasswordChar = false;
            }
            else
            {
                PBPwdShow.BackColor = Color.FromArgb(0);
                TxtPwd.UseSystemPasswordChar = true;
            }
        }

        private void BtnForgotPwd_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword fp = new ForgotPassword();
            fp.Show();
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string id = TxtId.Text;
            string pwd = TxtPwd.Text;
            bool admin = RBAdmin.Checked;

            if (id == "" || pwd == "" || id == "Enter You ID Here Please" || pwd == "Enter You PWD Here Please")
            {
                alert("Please Enter the Credentials");
            }
            else
            {
                String cs = "server = JARVIS\\sqlexpress; database = spencers; Integrated Security = True;";
                SqlConnection conn = new SqlConnection(cs);
                string command = " SELECT * FROM users WHERE id = '" + id + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(command, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    i++;
                    seller sr = new seller(id);
                    admin ad = new admin(id);

                    if (pwd == dr["pwd"].ToString()) // && id == dr["id"].ToString())
                    {// id matched
                        if (dr["active"].ToString() == "true")
                        {// Active User 
                            if (RBAdmin.Checked)
                            {// want to login as admin
                                if (dr["admin"].ToString() == "true      " || dr["admin"].ToString() == "true")
                                {
                                    // eligble for admin
                                    this.Hide();
                                    ad.Show();
                                }
                                else
                                {
                                    // not eligble for admin
                                    alert("You Are Not an Admin. Redirecting to Attedent' Page","sr page");
                                }
                            }
                            else
                            { // admin not Selected
                                this.Hide();
                                sr.Show();
                            }
                        }
                        else
                        {// not active user
                            alert("Please Contact to any admin", "Account Deactivated");
                        }
                    }
                    else // id not matched
                    {
                        alert("Please!!!... Wrong Password.");
                    }
                }
                if (i == 0)
                    alert("User Not Found");

            }


        }

        private void BtnAlert_Click(object sender, EventArgs e)
        {
            PnlAlert.Visible = false;
            seller sr = new seller(TxtId.Text);
            if (Operation_type == "sr page")
            {
                sr.Show();
                this.Hide();
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
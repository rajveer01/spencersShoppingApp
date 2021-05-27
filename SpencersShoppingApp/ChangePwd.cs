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
    public partial class ChangePwd : Form
    {
        string id;
        bool adminn;
        public ChangePwd(string id2,bool adm = false)
        {
            InitializeComponent();
            id = id2;
            adminn = adm;
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


        private void ChangePwd_Load(object sender, EventArgs e)
        {
            TxtId.Text = id;
        }

        private void TxtPwdOld_Enter(object sender, EventArgs e)
        {
            if (TxtPwdOld.Text == "Enter Old PWD Here Please")
            {
                TxtPwdOld.Text = "";
                TxtPwdOld.UseSystemPasswordChar = true;
                PBOPwdShow.BackColor = Color.FromArgb(0);
            }
        }

        private void TxtPwdNew_Enter(object sender, EventArgs e)
        {
            if (TxtPwdNew.Text == "Enter New PWD Here Please")
            {
                TxtPwdNew.Text = "";
                TxtPwdNew.UseSystemPasswordChar = true;
                PBNPwdShow.BackColor = Color.FromArgb(0);
            }
        }

        private void TxtPwdRnew_Enter(object sender, EventArgs e)
        {
            if (TxtPwdRnew.Text == "Re-Enter New PWD Here Please")
            {
                TxtPwdRnew.Text = "";
                TxtPwdRnew.UseSystemPasswordChar = true;
                PBRNPwdShow.BackColor = Color.FromArgb(0);
            }
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            if (TxtPwdOld.Text == "" || TxtPwdNew.Text == "" || TxtPwdRnew.Text == "" || TxtPwdOld.Text == "Enter Old PWD Here Please" || TxtPwdNew.Text == "Enter New PWD Here Please" || TxtPwdRnew.Text == "Re-Enter New PWD Here Please")
            {
                alert("Please Fill All Three Boxes At least");
            }
            else
            {// if Not Empty all
                if (TxtPwdNew.Text != TxtPwdRnew.Text)
                {
                    alert("New Password is not the same in Both boxes");
                }
                else
                {// if rnew same as new pwd
                    bool flag_oPm = false;
                    string cs = "server = Jarvis\\sqlexpress; Database = spencers; Integrated Security = true;";
                    SqlConnection conn = new SqlConnection(cs);
                    conn.Open();
                    string command = "SELECT * FROM users WHERE id = " + id;
                    SqlCommand cmd = new SqlCommand(command, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (TxtPwdOld.Text == dr["pwd"].ToString())
                        {
                            flag_oPm = true;
                        }
                        else
                        {// If old Pwd Is Wrong
                            alert("Incorrect PWD");
                        }
                    }
                    dr.Close();
                    if (flag_oPm)
                    {
                        command = "UPDATE users SET pwd = '" + TxtPwdNew.Text + "' WHERE id = '" + id + "'";
                        SqlCommand cmd2 = new SqlCommand(command, conn);
                        cmd2.ExecuteNonQuery();
                        alert("Password has been Changed. Now Login Again.", "show login", "Password Changed");
                    }
                    conn.Close();
                }
            }
        }
        private void PBOPwdShow_Click(object sender, EventArgs e)
        {
            if (TxtPwdOld.UseSystemPasswordChar)
            {
                TxtPwdOld.UseSystemPasswordChar = false;
                PBOPwdShow.BackColor = Color.DimGray;
            }
            else
            {
                TxtPwdOld.UseSystemPasswordChar = true;
                PBOPwdShow.BackColor = Color.FromArgb(0);
            }
        }

        private void PBNPwdShow_Click(object sender, EventArgs e)
        {
            if (TxtPwdNew.UseSystemPasswordChar)
            {
                TxtPwdNew.UseSystemPasswordChar = false;
                PBNPwdShow.BackColor = Color.DimGray;
            }
            else
            {
                TxtPwdNew.UseSystemPasswordChar = true;
                PBNPwdShow.BackColor = Color.FromArgb(0);
            }
        }

        private void PBRNPwdShow_Click(object sender, EventArgs e)
        {
            if (TxtPwdRnew.UseSystemPasswordChar)
            {
                TxtPwdRnew.UseSystemPasswordChar = false;
                PBRNPwdShow.BackColor = Color.Gray;
            }
            else
            {
                TxtPwdRnew.UseSystemPasswordChar = true;
                PBRNPwdShow.BackColor = Color.FromArgb(0);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            alert("Nothing is Changed", "show seller", "No Change.");
        }

        private void BtnAlert_Click(object sender, EventArgs e)
        {
            if (Operation_type == "show login")
            {
                this.Hide();
                Login lg = new Login();
                lg.Show();
            }
            else if (Operation_type == "show seller")
            {
                this.Hide();
                seller sr = new seller(id);
                admin ad = new admin(id);
                if (adminn)
                    ad.Show();
                else
                    sr.Show();
            }
            else
            {
                PnlAlert.Visible = false;
            }
        }

        
    }
}

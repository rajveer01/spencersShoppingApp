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
    public partial class admin : Form
    {
        string id;
        public admin(string id2)
        {
            InitializeComponent();
            id = id2;
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

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void BtnChangePwd_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePwd cp = new ChangePwd(id, true);
            cp.Show();
        }

        private void BtnVATxn_Click(object sender, EventArgs e)
        {
            this.Hide();
            OldTxn ot = new OldTxn(id, true);
            ot.Show();
        }

        private void TxtOtherProfile_Enter(object sender, EventArgs e)
        {
            if (TxtOtherProfile.Text == "Enter Other's ID Here Please")
                TxtOtherProfile.Text = "";
        }

        private void TxtDeactUser_Enter(object sender, EventArgs e)
        {
            if (TxtDeactUser.Text == "Enter Other's ID Here Please")
                TxtDeactUser.Text = "";
        }

        private void TxtActUser_Enter(object sender, EventArgs e)
        {
            if (TxtActUser.Text == "Enter Other's ID Here Please")
                TxtActUser.Text = "";
        }

        private void TxtOtherTxn_Enter(object sender, EventArgs e)
        {
            if (TxtOtherTxn.Text == "Enter Other's ID Here Please")
                TxtOtherTxn.Text = "";
        }

        private void TxtPwdRecover_Enter(object sender, EventArgs e)
        {
            if (TxtPwdRecover.Text == "Enter Other's ID Here Please")
                TxtPwdRecover.Text = "";
        }

        private void BtnDeactUser_Click(object sender, EventArgs e)
        {
            if (TxtDeactUser.Text != "" && TxtDeactUser.Text!="Enter Other's ID Here Please")
            {
                string cs = "Server=Jarvis\\sqlexpress; database=spencers; Integrated security = true;";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                string command = "update users set active = 'false' where id = '" + TxtDeactUser.Text + "'";
                SqlCommand cmd = new SqlCommand(command, conn);
                int exec = cmd.ExecuteNonQuery();
                if (exec == 1)
                    alert("Deactivated.", "0", "Account Deactivated.");
                else
                    alert("No Account Found.", "0");
            }
            else
                alert("Please Enter Id");
        }

        private void BtnActUser_Click(object sender, EventArgs e)
        {
            if (TxtActUser.Text != "" && TxtActUser.Text != "Enter Other's ID Here Please")
            {
                string cs = "Server=Jarvis\\sqlexpress; database=spencers; Integrated security = true;";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                string command = "update users set active = 'true' where id = '" + TxtActUser.Text + "'";
                SqlCommand cmd = new SqlCommand(command, conn);
                int exec = cmd.ExecuteNonQuery();
                if (exec == 1)
                    alert("Activated.", "0", "Account Activated.");
                else
                    alert("No Account Found.", "0");
            }
            else
                alert("Please Enter Id");
        }

        private void BtnPwdRecover_Click(object sender, EventArgs e)
        {
            if (TxtPwdRecover.Text != "" && TxtPwdRecover.Text != "Enter Other's ID Here Please")
            {
                string cs = "Server=Jarvis\\sqlexpress; database=spencers; Integrated security = true;";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                string command = "Select * from users where id = '" + TxtPwdRecover.Text + "'";
                SqlCommand cmd = new SqlCommand(command, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    i++;
                    alert(dr["pwd"].ToString(),"0", "The Password Is");
                }
                if (i == 0)
                    alert("User Not Exists");
            }
            else
                alert("Please Enter Id");
        }

        private void BtnOtherTxn_Click(object sender, EventArgs e)
        {
            if (TxtOtherTxn.Text != "Enter Other's ID Here Please" && TxtOtherTxn.Text != "")
            {
                OldTxn ol = new OldTxn(id, true, TxtOtherTxn.Text);
                ol.Show();
                this.Hide();
            }
            else
                alert("Please Enter Id");
        }

        private void BtnYourProfile_Click(object sender, EventArgs e)
        {
            Profile pf = new Profile(id, true);
            pf.Show();
            this.Hide();
        }

        private void BtnOtherProfile_Click(object sender, EventArgs e)
        {
            if (TxtOtherProfile.Text != "Enter Other's ID Here Please" && TxtOtherProfile.Text != "")
            {
                Profile pf = new Profile(id, true, TxtOtherProfile.Text);
                pf.Show();
                this.Hide();
            }
            else
                alert("Please Enter Id");
        }

        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            AddUser au = new AddUser(id);
            au.Show();
            this.Hide();
        }

        private void BtnAlert_Click(object sender, EventArgs e)
        {
            PnlAlert.Visible = false;
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct ap = new AddProduct(id);
            ap.Show();
            this.Hide();
        }

    }
}

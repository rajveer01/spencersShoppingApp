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
    public partial class AddUser : Form
    {
        String id;
        public AddUser(string id2)
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

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            admin ad = new admin(id);
            this.Hide();
            ad.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }

        string cs = "server = Jarvis\\sqlexpress; Database = spencers; Integrated Security = true";
        string command = " ";
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "" || TxtName.Text == "" || TxtPwd.Text == "" || CBSecQu.SelectedItem == "" || Txtsal.Text == "" || TxtSecAns.Text == "" || TxtAddr.Text == "")
            {
                alert("Please Enter Details.");
                return;
            }
            BtnAddUser.Enabled = false;

            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand cmd;
            SqlDataReader dr;
            int no = 0;
            command = "select id from users where id = '" + TxtId.Text + "'";
            cmd = new SqlCommand(command, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                no++;
            }
            dr.Close();
            if (no == 0)
            {
                command = "insert into users values (" + TxtId.Text + " , '" + TxtName.Text + "','" + TxtPwd.Text + "','" + TxtAddr.Text + "','" + TxtSecAns.Text + "','" + CBSecQu.SelectedIndex + "',";
                if (RBActive.Checked)
                    command += "'true',";
                else
                    command += "'false',";
                if (RBAdmin.Checked)
                    command += "'true','1','" + Txtsal.Text + "')";
                else
                    command += "'false','1','" + Txtsal.Text + "')";
                cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
            }
            alert("User Added", "show admin", "Yippi!!!");
            
        }

        private void AddUser_Load(object sender, EventArgs e)
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
            TxtSecAns.Focus();
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

        private void BtnPic_Click(object sender, EventArgs e)
        {
            alert("This Feature Is premium");
            PBProfile.Image = Image.FromFile("C:/Users/Toppers at Top/Documents/Visual Studio 2010/Projects/Spencers shopping/" + 0 + ".png");
        }

        private void BtnAlert_Click(object sender, EventArgs e)
        {
            PnlAlert.Visible = false;
            if (Operation_type == "show admin")
            {
                admin ad = new admin(id);
                ad.Show();
                this.Hide();
            }
        }
    }
}

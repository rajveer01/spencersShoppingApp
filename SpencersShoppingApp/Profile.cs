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
    public partial class Profile : Form 
    {
        string id, uid;
        bool adminn;
        public Profile(string id2, bool adm = false, string uidd = null)
        {
            InitializeComponent();
            id = id2;
            adminn = adm;
            uid = uidd;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            string cs = "server = Jarvis\\sqlexpress; database = spencers; Integrated security = true;";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            string command;
            if (adminn && uid != null)
            {
                PBProfile.Image = Image.FromFile("C:/Users/Toppers at Top/Documents/Visual Studio 2010/Projects/Spencers shopping/" + 0 + ".png");
                command = "SELECT * FROM users WHERE id = '" + uid + "'";
            }
            else
            {
                PBProfile.Image = Image.FromFile("C:/Users/Toppers at Top/Documents/Visual Studio 2010/Projects/Spencers shopping/" + id + ".png");
                command = "SELECT * FROM users WHERE id = '" + id + "'";
            }
            
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LblId.Text = dr["id"].ToString();
                LblName.Text = dr["name"].ToString();
                LblAddr.Text = dr["addr"].ToString();
                if (dr["admin"].ToString() == "true")
                    LblStatus.Text = "You are an Admin";
                else
                    LblStatus.Text = "You are an Attendent";
                LblSalary.Text = "INR " + dr["salary"].ToString() + ".00";
            }
            dr.Close();

            if (adminn && uid != null)
            {
                command = "select count(distinct(tid)) from txn where sellerid='" + uid + "'";
            }
            else
            {
                command = "select count(distinct(tid)) from txn where sellerid='" + id + "'";
            }
            cmd = new SqlCommand(command, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LblTxn.Text = dr[0].ToString();
            }

        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void BtnChangePwd_Click(object sender, EventArgs e)
        {
            seller sr = new seller(id);
            admin ad = new admin(id);
            if (adminn)
                ad.Show();
            else
                sr.Show();
            this.Hide();
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
    }
}

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
    public partial class OldTxn : Form
    {
        string id;
        bool adminn;
        string uid;
        public OldTxn(string id2,bool adm = false, string uidd = null )
        {
            InitializeComponent();
            id = id2;
            adminn = adm;
            uid = uidd;
        }

        Panel[] PnlTId = new Panel[1000];
        Panel[] PnlName = new Panel[1000];
        Panel[] PnlPid = new Panel[1000];
        Panel[] PnlQuty = new Panel[1000];

        Label[] LblId = new Label[1000];
        Label[] LblName = new Label[1000];
        Label[] LblPid = new Label[1000];
        Label[] LblQuty = new Label[1000];

        private void OldTxn_Load(object sender, EventArgs e)
        {

            String cs = "server = JARVIS\\sqlexpress; database = spencers; Integrated Security = True;";
            SqlConnection conn = new SqlConnection(cs);
            string command;
            if (adminn && uid == null)
                command = " SELECT t.tid,t.pid,t.quantity,p.pname from txn as t inner join products as p on t.pid = p.pid WHERE t.tid<>0 and p.pid<>0 Order by t.tid";
            else if (adminn && uid != null)
                command = " SELECT t.tid,t.pid,t.quantity,p.pname from txn as t inner join products as p on t.pid = p.pid WHERE Sellerid = " + uid + "Order by t.tid";
            else
                command = " SELECT t.tid,t.pid,t.quantity,p.pname from txn as t inner join products as p on t.pid = p.pid WHERE Sellerid = " + id + "Order by t.tid";
            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                PnlTId[i] = new Panel();
                PnlName[i] = new Panel();
                PnlPid[i] = new Panel();
                PnlQuty[i] = new Panel();

                PnlTId[i].Height = PnlName[i].Height = PnlPid[i].Height = PnlQuty[i].Height = 45;
                PnlTId[i].Width = 150; PnlName[i].Width = 350; PnlPid[i].Width = 210; PnlQuty[i].Width = 210;
                PnlTId[i].BackColor = PnlName[i].BackColor = PnlPid[i].BackColor = PnlQuty[i].BackColor = Color.White;
                FLPanel.Controls.Add(PnlTId[i]); FLPanel.Controls.Add(PnlName[i]); FLPanel.Controls.Add(PnlPid[i]); FLPanel.Controls.Add(PnlQuty[i]);
                
                LblId[i] = new Label();
                LblName[i] = new Label();
                LblPid[i] = new Label();
                LblQuty[i] = new Label();

                LblId[i].Location = LblName[i].Location = LblPid[i].Location = LblQuty[i].Location = new Point(9, 10);
                LblId[i].Text = dr["tid"].ToString(); LblName[i].Text = dr["pname"].ToString(); LblPid[i].Text = dr["pid"].ToString(); LblQuty[i].Text = dr["quantity"].ToString();
                PnlTId[i].Controls.Add(LblId[i]); PnlName[i].Controls.Add(LblName[i]); PnlPid[i].Controls.Add(LblPid[i]); PnlQuty[i].Controls.Add(LblQuty[i]);
                i++;
            }
            
        }

        private void BtnAlert_Click(object sender, EventArgs e)
        {
            PnlAlert.Visible = false;
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

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            seller sr = new seller(id);
            admin ad = new admin(id);
            if (adminn)
                ad.Show();
            else
                sr.Show();
        }

        
    }
}

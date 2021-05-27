using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpencersShoppingApp
{
    public partial class seller : Form
    {
        string id;
        public seller(string id2)
        {
            InitializeComponent();
            id = id2;
        }

        private void BtnMin_MouseHover(object sender, EventArgs e)
        {
            LblPnlCloseMsg.Text = "Minimise";
        }

        private void BtnMin_MouseLeave(object sender, EventArgs e)
        {
            LblPnlCloseMsg.Text = "";
        }

        private void BtnCalc_MouseHover(object sender, EventArgs e)
        {
            LblPnlCloseMsg.Text = "Calculator";
        }

        private void BtnCalc_MouseLeave(object sender, EventArgs e)
        {
            LblPnlCloseMsg.Text = "";
        }

        private void BtnCloseApp_MouseHover(object sender, EventArgs e)
        {
            LblPnlCloseMsg.Text = "Close";
        }

        private void BtnCloseApp_MouseLeave(object sender, EventArgs e)
        {
            LblPnlCloseMsg.Text = "";
        }

        private void BtnNewtxn_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewTxn nt = new NewTxn(id);
            nt.Show();
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
            p.Close();
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void BtnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login ln = new Login();
            ln.Show();
        }

        private void BtnNewtxn_MouseEnter(object sender, EventArgs e)
        {
            BtnNewtxn.ForeColor = Color.Black;
            BtnNewtxn.BackColor = Color.FromArgb(150, 192, 192, 192);
        }

        private void BtnNewtxn_MouseLeave(object sender, EventArgs e)
        {
            BtnNewtxn.ForeColor = Color.White;
            BtnNewtxn.BackColor = Color.Maroon;
        }

      

        private void BtnOldTxn_MouseEnter(object sender, EventArgs e)
        {

            BtnOldTxn.ForeColor = Color.Black;
            BtnOldTxn.BackColor = Color.FromArgb(150, 192, 192, 192);
        }

        private void BtnChangePwd_MouseEnter(object sender, EventArgs e)
        {

            BtnChangePwd.ForeColor = Color.Black;
            BtnChangePwd.BackColor = Color.FromArgb(150, 192, 192, 192);
        }

        private void BtnProfile_MouseEnter(object sender, EventArgs e)
        {

            BtnProfile.ForeColor = Color.Black;
            BtnProfile.BackColor = Color.FromArgb(150, 192, 192, 192);
        }

        private void BtnLogout_MouseEnter(object sender, EventArgs e)
        {

            BtnLogout.ForeColor = Color.Black;
            BtnLogout.BackColor = Color.FromArgb(150, 192, 192, 192);
        }

        private void BtnOldTxn_MouseLeave(object sender, EventArgs e)
        {
            BtnOldTxn.ForeColor = Color.White;
            BtnOldTxn.BackColor = Color.Maroon;
        }

        private void BtnChangePwd_MouseLeave(object sender, EventArgs e)
        {
            BtnChangePwd.ForeColor = Color.White;
            BtnChangePwd.BackColor = Color.Maroon;
        }

        private void BtnProfile_MouseLeave(object sender, EventArgs e)
        {
            BtnProfile.ForeColor = Color.White;
            BtnProfile.BackColor = Color.Maroon;
        }

        private void BtnLogout_MouseLeave(object sender, EventArgs e)
        {
            BtnLogout.ForeColor = Color.White;
            BtnLogout.BackColor = Color.Maroon;
        }

        private void BtnPendTxn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddProduct pd = new AddProduct(id);
            pd.Show();
        }

        private void BtnOldTxn_Click(object sender, EventArgs e)
        {
            this.Hide();
            OldTxn ot = new OldTxn(id);
            ot.Show();
        }

        private void BtnChangePwd_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePwd cp = new ChangePwd(id);
            cp.Show();
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile pr = new Profile(id);
            pr.Show();
        }

        private void BtnRequest_Click(object sender, EventArgs e)
        {
            this.Hide();
            Request rq = new Request();
            rq.Show();
        }

    }
}

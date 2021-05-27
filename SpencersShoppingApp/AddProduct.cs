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
    public partial class AddProduct : Form
    {
        string id;
        public AddProduct(string id2)
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

        private void TxtQuty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtProfit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtQuty_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TxtQuty.Text, "  ^ [0-9]"))
            {
                TxtQuty.Text = "";
            }
        }

        private void TxtCost_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TxtCost.Text, "  ^ [0-9]"))
            {
                TxtCost.Text = "";
            }
        }

        private void TxtDisc_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TxtDisc.Text, "  ^ [0-9]"))
            {
                TxtDisc.Text = "";
            }
        }

        private void TxtProfit_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TxtProfit.Text, "  ^ [0-9]"))
            {
                TxtProfit.Text = "";
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
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            admin ad = new admin(id);
            ad.Show();
            this.Hide();
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            string cs = "Server=Jarvis\\sqlexpress; database=spencers; Integrated security = true;";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            string command = "declare @id as int begin set @id = " + TxtId.Text + " if @id = (select pid from products where pid = @id) begin update products set pname = '" + TxtName.Text + "', cost = '" + TxtCost.Text + "', discount='" + TxtDisc.Text + " ', quantity= quantity + " + TxtQuty.Text + ", profit = '" + TxtProfit.Text + "' where pid = @id end else begin insert into products values(@id,'" + TxtName.Text + "','" + TxtCost.Text + "','" + TxtDisc.Text + "','" + TxtQuty.Text + "','" + TxtProfit.Text + "',null) end end";
            SqlCommand cmd = new SqlCommand(command, conn);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                TxtName.Clear(); TxtId.Clear(); TxtDisc.Clear(); TxtCost.Clear(); TxtQuty.Clear(); TxtProfit.Clear(); TxtName.Focus();
                alert("Product Added", "0", "OK");
            }
            else
            {
                alert("Something Went Wrong");
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

    }
}

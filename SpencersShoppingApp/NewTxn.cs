using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace SpencersShoppingApp
{
    public partial class NewTxn : Form
    {
        string id;
        public NewTxn(string id2)
        {
            id = id2;
            InitializeComponent();
        }
        static int countE(string[] a)
        {
            for (int i = 0; i <= a.Length; i++)
            {
                if (a[i] == null)
                    return i;
            }
            return 0;
        
        }

        static void Arraynull(string[] a)
        {
            for (int i = 0; i < countE(a); i++)
            {
                product[i] = null;
            }
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


        static void AddArrayE(string[] a)
        {
            int j = 0;
            int k = a.Length + countE(product);
            for (int i = countE(product); i < k; i++)
            {
                product[i] = a[j];
                j++;
            }
        }

        Panel[] PnlNo = new Panel[30];
        Panel[] PnlName = new Panel[30];
        Panel[] PnlId = new Panel[30];
        Panel[] PnlCost = new Panel[30];
        Panel[] PnlDisc = new Panel[30];
        Panel[] PnlQuty = new Panel[30];
        Panel[] PnlTotal = new Panel[30];

        Label[] LblNo = new Label[30];
        Label[] LblName = new Label[30];
        Label[] LblId = new Label[30];
        Label[] LblCost = new Label[30];
        Label[] LblDisc = new Label[30];
        NumericUpDown[] NmQuty = new NumericUpDown[30];
        Label[] LblTotal = new Label[30];

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (BtnAdd.Text == "Stop Adding")
            {
                timer1.Enabled = false;
                BtnAdd.Text = "Add Products";
            }
            else
            {
                timer1.Enabled = true;
                BtnAdd.Text = "Stop Adding";
            }
        }
        static string[] product = new string[100];
        int index = 0;
        int index2 = 1;
        static int no_control = 0;
        static double price = 0;
        static double total = 0;
        string cs = "server = JARVIS\\sqlexpress; database = spencers; Integrated Security = True;";

        private void timer1_Tick(object sender, EventArgs e)
        {
            string ch = File.ReadAllText("C:/Users/Toppers at Top/Documents/Visual Studio 2010/Projects/SpencersShoppingApp/Products.txt");
            bool dofor = true;
            string[] products = File.ReadAllLines("C:/Users/Toppers at Top/Documents/Visual Studio 2010/Projects/SpencersShoppingApp/Products.txt");
            if (ch == "")
            {
                dofor = false;
            }
            else
                AddArrayE(products);
            File.WriteAllText("C:/Users/Toppers at Top/Documents/Visual Studio 2010/Projects/SpencersShoppingApp/Products.txt", "");
            if (dofor)
                for (int i = index; i < countE(product); i++, index++, index2++, no_control++)
                {
                    PnlNo[i] = new Panel();
                    PnlName[i] = new Panel();
                    PnlId[i] = new Panel();
                    PnlCost[i] = new Panel();
                    PnlDisc[i] = new Panel();
                    PnlQuty[i] = new Panel();
                    PnlTotal[i] = new Panel();
                    FLPanel.Controls.Add(PnlNo[i]); FLPanel.Controls.Add(PnlName[i]); FLPanel.Controls.Add(PnlId[i]); FLPanel.Controls.Add(PnlCost[i]); FLPanel.Controls.Add(PnlDisc[i]); FLPanel.Controls.Add(PnlQuty[i]); FLPanel.Controls.Add(PnlTotal[i]);
                    PnlNo[i].BackColor = Color.FromArgb(255, 255, 255, 255);
                    PnlName[i].BackColor = Color.White;
                    PnlId[i].BackColor = Color.White;
                    PnlCost[i].BackColor = Color.White;
                    PnlDisc[i].BackColor = Color.White;
                    PnlQuty[i].BackColor = Color.White;
                    PnlTotal[i].BackColor = Color.White;
                    PnlNo[i].Height = PnlName[i].Height = PnlId[i].Height = PnlCost[i].Height = PnlDisc[i].Height = PnlQuty[i].Height = PnlTotal[i].Height = 45;
                    PnlNo[i].Width = 60; PnlName[i].Width = 290; PnlId[i].Width = 140; PnlCost[i].Width = 90; PnlDisc[i].Width = 120; PnlQuty[i].Width = 100; PnlTotal[i].Width = 100;

                    LblNo[i] = new Label();
                    LblName[i] = new Label();
                    LblId[i] = new Label();
                    LblCost[i] = new Label();
                    LblDisc[i] = new Label();
                    NmQuty[i] = new NumericUpDown();
                    LblTotal[i] = new Label();

                    LblNo[i].Text = index2.ToString();
                    PnlNo[i].Controls.Add(LblNo[i]);
                    LblNo[i].Location = new Point(9, 10);

                    LblId[i].Text = product[index];
                    PnlId[i].Controls.Add(LblId[i]);
                    LblId[i].Location = new Point(10, 10);

                    NmQuty[i].Value = 1;
                    PnlQuty[i].Controls.Add(NmQuty[i]);
                    NmQuty[i].Location = new Point(10, 10);
                    NmQuty[i].Width = 80;

                    PnlName[i].Controls.Add(LblName[i]);
                    LblName[i].Location = new Point(9, 10);
                    PnlCost[i].Controls.Add(LblCost[i]);
                    LblCost[i].Location = new Point(9, 10);
                    PnlDisc[i].Controls.Add(LblDisc[i]);
                    LblDisc[i].Location = new Point(9, 10);
                    PnlTotal[i].Controls.Add(LblTotal[i]);
                    LblTotal[i].Location = new Point(9, 10);

                    SqlConnection conn = new SqlConnection(cs);
                    conn.Open();
                    string command = "Select * from products where pid = '" + product[index] + "'";
                    SqlCommand cmd = new SqlCommand(command, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        LblName[i].Text = dr["pname"].ToString();
                        LblCost[i].Text = dr["cost"].ToString();
                        LblDisc[i].Text = dr["discount"].ToString();
                    }
                    price = double.Parse(LblCost[i].Text) * (100 - double.Parse(LblDisc[i].Text)) / 100;
                    LblTotal[i].Text = price.ToString();

                    total += double.Parse(LblTotal[i].Text);
                    LblNetTot.Text = total.ToString();
                    NmQuty[i].ValueChanged += new EventHandler(this.NmQutyValueChanged);

                }
        }
        void NmQutyValueChanged(Object sender, EventArgs e)
        {
            //NumericUpDown NmQuty = (sender as NumericUpDown);
            total = 0;
            for (int i = 0; i < no_control; i++)
            {
                LblTotal[i].Text = (Convert.ToDouble(Convert.ToInt32(NmQuty[i].Value)) * double.Parse(LblCost[i].Text) * (100 - double.Parse(LblDisc[i].Text)) / 100).ToString();
                total += double.Parse(LblTotal[i].Text);
                LblNetTot.Text = total.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            //Arraynull(product);
            timer1.Enabled = false;
            seller sr = new seller(id);
            this.Hide();
            sr.Show();
        }

        private void ProcPay_Click(object sender, EventArgs e)
        {
            ProcPay.Enabled = false;
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            string command;
            for (int i = 0; i < index; i++)
            {
                if (i == 0)
                    command = "insert into txn values(cast((select max(tid) from txn) as int) + 1 ," + LblId[i].Text + " ," + id + ", 0, " + NmQuty[i].Value + ")";
                else
                    command = "insert into txn values(cast((select max(tid) from txn) as int) ," + LblId[i].Text + " ," + id + ", 0, " + NmQuty[i].Value + ")";
                command += "update products set quantity = quantity - " + NmQuty[i].Value + " where pid = '" + LblId[i].Text + "'";
                SqlCommand cmd = new SqlCommand(command, conn);
                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    alert("Transaction Done.", "1", "OK");
                }
                else
                {
                    alert("Something Went Wrong");
                }
            }


            //Arraynull(product);
        }

        private void BtnAlert_Click(object sender, EventArgs e)
        {
            PnlAlert.Hide();
            if (Operation_type == "1")
            {
                seller sr = new seller(id);
                sr.Show();
                this.Hide();
            }
        }



    }
}

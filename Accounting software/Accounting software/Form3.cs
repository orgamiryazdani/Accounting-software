using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting_software
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string price = textBox2.Text;
                string brand = textBox3.Text;
                if(name != "" && price != "" && brand != "")
                {
                    string line = name + "," + price + "," + brand + "\n";
                    File.AppendAllText("product.csv", line);
                    label4.Text = "";
                    MessageBox.Show("محصول اضافه شد");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    label4.Text = "لطفا مقادیر خواسته شده را پر کنید";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}

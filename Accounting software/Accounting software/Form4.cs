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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Accounting_software
{
    public partial class Form4 : Form
    {
        private List<string[]> customerDataList = new List<string[]>();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines("customer.csv");

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];

                    if (line.Contains(","))
                    {
                        int commaIndex = line.IndexOf(",");
                        string name = line.Substring(0, commaIndex);
                        listBox1.Items.Add(name);
                        // افزودن اطلاعات به لیست
                        customerDataList.Add(line.Split(','));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                try
                {
                    string[] parts = customerDataList[listBox1.SelectedIndex];

                        label4.Text = parts[0]; 
                        label5.Text = parts[1]; 
                        label6.Text = parts[2]; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطا در خواندن اطلاعات: " + ex.Message);
                }
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}


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
    public partial class Form5 : Form
    {
        private List<string[]> customerDataList = new List<string[]>();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines("product.csv");

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

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
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
    }
}

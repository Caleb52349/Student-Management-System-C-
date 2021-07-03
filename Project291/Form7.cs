using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project291
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public string nextItem()
        {
            j = j + 1; // increases i by one
            j = j % lines.Length; // if we go too high , start from "0" again
            return lines[j];// gives us back the item of where we are now
        }

        public string PrevItem()
        {
            if (j == 0) // i would be 0
            {
                j = lines.Length;
            }
            j = j - 1; // decreases by one
            return lines[j];  // gives back the line where we are now
        }
        string[] lines = File.ReadAllLines("Class.txt");  // stores readline into string array called lines
        int j = 0;
        int current = 0;  //int of current initialised at 0
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("Class.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string s;
                s = sr.ReadLine();
                int i;
                i = s.IndexOf("  ");
                string[] a = s.Split(','); // splits record after every ','
                foreach (string item in a) // array is stored for each readline
                {
                    label7.Text = a[0];
                    label8.Text = a[1];
                    label9.Text = a[2];
                    label11.Text = a[3];
                    label12.Text = a[4];
                    label13.Text = "24";

                }

                sr.Close();
                fs.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Please Add a Teacher Record. No record Stored", "No Record!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                this.Close();
            }
          

        }

        private void button5_Click(object sender, EventArgs e)
        {
            nextItem();  //next record of readline is called
            {
                if (current == lines.Length - 1)
                {
                    current = 0;
                }
                else
                {
                    current++;  // increments record to next record
                }


                string s;
                s = lines[current];
                int i;
                i = s.IndexOf("  ");
                string[] a = s.Split(',');
                foreach (string item in a) //splits readline to assigned labels.
                {
                    label7.Text = a[0];
                    label8.Text = a[1];
                    label9.Text = a[2];
                    label11.Text = a[3];
                    label12.Text = a[4];
                    label13.Text = "24";

                }

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrevItem();
            {
                if (current == 0)
                {
                    current = lines.Length - 1;

                }
                else
                {
                    current--; //decrements record of readline
                }
            }

            string s;
            s = lines[current];
            int i;
            i = s.IndexOf("  ");
            string[] a = s.Split(','); // splits record after every ','
            foreach (string item in a) // this kinda converts the readline and splits it to assigned labels as shown
            {
                label7.Text = a[0];
                label8.Text = a[1];
                label9.Text = a[2];
                label11.Text = a[3];
                label12.Text = a[4];
                label13.Text = "24";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update will be available soon", "Search engine currently not working", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            textBox2.Text = "";
        }
    }
}

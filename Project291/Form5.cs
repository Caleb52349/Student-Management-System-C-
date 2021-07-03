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
    public partial class Form5 : Form
    {
        public Form5()
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
        string[] lines = File.ReadAllLines("Student.txt");  // stores readline into string array called lines
        int j = 0;
        int current = 0;  //int of current initialised at 0
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("Student.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string s;
                s = sr.ReadLine();
                int i;
                i = s.IndexOf("  ");
                string[] a = s.Split(','); //splits record after every ','
                foreach (string item in a) // array is stored for each readline
                {
                    label12.Text = a[0];
                    label13.Text = a[1];
                    label14.Text = a[2];
                    label15.Text = a[3];
                    label16.Text = a[4];
                    label17.Text = a[5];
                    label18.Text = a[6];
                    label19.Text = a[7];
                    label20.Text = a[8];

                    pictureBox1.Image = Image.FromFile(a[9]);







                }




                sr.Close();
                fs.Close();

            }
            catch (Exception ex)
            {


                MessageBox.Show("Please Add a Student Record. No record Stored", "No Record!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                this.Close();
            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

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
                    label12.Text = a[0];
                    label13.Text = a[1];
                    label14.Text = a[2];
                    label15.Text = a[3];
                    label16.Text = a[4];
                    label17.Text = a[5];
                    label18.Text = a[6];
                    label19.Text = a[7];
                    label20.Text = a[8];

                    pictureBox1.Image = Image.FromFile(a[9]); // location of picture is stored in txt fil
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
                label12.Text = a[0];
                label13.Text = a[1];
                label14.Text = a[2];
                label15.Text = a[3];
                label16.Text = a[4];
                label17.Text = a[5];
                label18.Text = a[6];
                label19.Text = a[7];
                label20.Text = a[8];

                pictureBox1.Image = Image.FromFile(a[9]);
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update will be available soon", "Search engine currently not working", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            textBox2.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
        }
    }
    }

      



            
            
        
    

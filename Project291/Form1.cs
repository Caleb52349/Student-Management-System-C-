using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project291
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Exits application
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();

            fr2.Show(); //shows form 2
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Show(); //shows form 3
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();

            fr4.Show(); //shows form 4

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            fr5.Show(); //shows form 5
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            fr6.Show(); //shows form 6
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 fr7 = new Form7();
            fr7.Show(); //shows form 7

        }
    }
}

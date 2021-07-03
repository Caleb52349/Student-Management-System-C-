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
using System.Text.RegularExpressions;

namespace Project291
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public string RandomID() // function to randomize Id of School class 
        {
            Class c = new Class();
            int s;
            char l;
            Random rnd = new Random();
            s = rnd.Next(7850, 7880); // randomize number between 7850 -7880
            l = (char)rnd.Next('A', 'E'); // randomize letters between A-E

            return label7.Text = "C-" + s + l; //returns the overall Id which concatenates the random number and random letter
        }

        public bool isvalid_name(string n)
        {
            Regex check = new Regex(@"^([A-Z][a-z-A-z]+)$");
            bool valid = false;
            valid = check.IsMatch(n);
            if (valid == true)
            {
                return valid;
            }

            else
            {
                MessageBox.Show("Name Format is not correct");
                return valid;
            }
        }
            public void addClass() //Function to store class data
        {
            try
            {
                Class c = new Class();
                int s;
                string l;
                Random rnd = new Random();
                s = rnd.Next(7850, 7880);


                c.Id = label7.Text;
                c.subject = textBox2.Text;
                c.Teacher = comboBox1.Text;
                c.Grade = Convert.ToInt32(textBox3.Text);
                c.ECTS = Convert.ToInt32(textBox4.Text);

                FileStream fs = new FileStream("Class.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                // file operation to save class data to the Class.txt file.
                sw.WriteLine(c.Id + "," + c.subject + "," + c.Teacher + "," + c.Grade + "," + c.ECTS); // writes data as shown in the order



                sw.Close();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void isempty() //validation check if user hasnt inputed any data

        {
            if (label7.Text == "" | textBox2.Text== "" | comboBox1.Text == "" | textBox3.Text == "" | textBox4.Text == "" )
            {
                MessageBox.Show("Please Fill all records!!!");
            }

            else
            //when filled and saved record is stored.
            {
                MessageBox.Show("Class has been Created");
            }
        }
            private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // closes form
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isempty();
            isvalid_name(textBox2.Text);
            try
            {
                //ensure Grade and Ects is in range.
                if (Convert.ToInt32(textBox3.Text) >= 5 | Convert.ToInt32(textBox3.Text) == 0)
                {
                    MessageBox.Show("Grade should be between 1-5");
                }

                else if (Convert.ToInt32(textBox3.Text) >= 7 | Convert.ToInt32(textBox3.Text) == 0)
                {
                    MessageBox.Show("ECTS should be between 1-7");
                }
                else
                {
                    addClass(); // function to addclass is called
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            this.Close();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            RandomID(); // function to randomize Id.
            //As Teacher record is added . Teacher first name and last name is added to combobox of teacher in Add new Class form
            string[] lineofContents = File.ReadAllLines("Teacher.txt");
            foreach(var line in lineofContents)
            {
                string[] data = line.Split(',');
                comboBox1.Items.Add(data[0]+ " " +data[1]); // splits the data for firtst and lastname of the TEacher.txt file
            }
        }
    }
}

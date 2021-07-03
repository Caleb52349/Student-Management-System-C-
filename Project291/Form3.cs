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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void addPic() // Function to allow user to select desired Picture
        {
            {
                string imageLocation = "";
                OpenFileDialog f = new OpenFileDialog();
                f.Filter = "JPG(*.JPG)|*.jpg]| PNG files(*.png)|*.png";

                if (f.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = f.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                }
            }
        }
        public void isempty() //validation check if user hasnt inputed any data

        {
            if (NametxtBox.Text == "" | SurnametxtBox.Text == "" | comboBox1.Text == "" | DobtxtBox.Text == "" | comboBox2.Text == "" | FoStxtBox.Text == "" | PhonetxtBox.Text == "" | EmailtxtBox.Text == "" | AddtxtBox.Text =="" |pictureBox1.Image is null)
            {
                MessageBox.Show("Please Fill all records!!!");
            }

            else
            //when filled and saved record is stored.
            {
                MessageBox.Show("Teacher has been Created");
            }
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

        public bool isvalid_surname(string n)
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
                MessageBox.Show("SUrname Format is not correct");
                return valid;
            }
        }

        public bool isvalid_email(string n)
        {
            Regex check = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            bool valid = false;
            valid = check.IsMatch(n);
            if (valid == true)
            {
                return valid;
            }

            else
            {
                MessageBox.Show("Email Format is not correct");
                return valid;
            }
        }

        public bool isvalid_DOB(string n)
        {

            Regex check = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$");
            bool valid = false;
            valid = check.IsMatch(n);
            if (valid == true)
            {
                return valid;
            }

            else
            {
                MessageBox.Show("Date of Birth Must be dd-mm-yyyy format");
                return valid;
            }

        }
        public bool isvalid_phone(string n)
        {
            Regex check = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
            bool valid = false;
            valid = check.IsMatch(n);
            if (valid == true)
            {
                return valid;
            }

            else
            {
                MessageBox.Show("Phone Format is not correct");
                return valid;
            }
        }
            public void addTeacher() // fucntion to add records of teacher
        {
            try
            {
                Teacher t = new Teacher();

                t.Name = NametxtBox.Text;
                t.Surname = SurnametxtBox.Text;
                t.Gender = comboBox1.Text;
                t.dob = DobtxtBox.Text;
                t.Education = comboBox2.Text;
                t.fieldofStudy = FoStxtBox.Text;
                t.PhoneNumber = Convert.ToInt32(PhonetxtBox.Text);
                t.Email = EmailtxtBox.Text;
                t.Address = AddtxtBox.Text;

                FileStream fs = new FileStream("Teacher.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                // file operation to save student record once it has been entered.
                sw.WriteLine(t.Name + "," + t.Surname + "," + t.Gender + "," + t.dob + "," + t.Education + "," + t.fieldofStudy + "," + t.PhoneNumber + "," + t.Email + "," + t.Address + "," + pictureBox1.ImageLocation);



                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
        
        }
    


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // closes the form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addPic(); // function to allow user to add desired picture
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isempty();
            //Validation checks
            isvalid_name(NametxtBox.Text);
            isvalid_surname(SurnametxtBox.Text);
            isvalid_DOB(DobtxtBox.Text);
            isvalid_phone(PhonetxtBox.Text);
            isvalid_email(EmailtxtBox.Text);
            addTeacher(); // function to add Teacher record.
            this.Close();
        }
    }
}

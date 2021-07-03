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
using System.Text.RegularExpressions; // to use macthing expression

namespace Project291
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int s;
            Random rnd = new Random();
            s = rnd.Next(5000, 6000); // random number for student ID

            label10.Text = s.ToString();  
        }
        public void addPic() // function to Addpicture to record
        {
            {
                string imageLocation = "";
                OpenFileDialog f = new OpenFileDialog();
                f.Filter = "JPG(*.JPG)|*.jpg]| PNG files(*.png)|*.png"; // file extention of pictures. png and jpg supported only

                if (f.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = f.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                }
            }
        }

        public void addStudent() // function to add student
        {

            try
            {
                Student s = new Student();
                //stores student record in the textboxes
                s.Name = NametxtBox.Text;
                s.Surname = SurnametxtBox.Text;
                s.Gender = comboBox1.Text;
                s.dob = DobtxtBox.Text;
                s.grade = Convert.ToInt32(GradetxtBox.Text);
                s.PhoneNumber = Convert.ToInt32(PhonetxtBox.Text);
                s.Email = EmailtxtBox.Text;
                s.Address = AddresstxtBox.Text;

                FileStream fs = new FileStream("Student.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                //stores the student records in the Student.txt file
                sw.WriteLine(label10.Text + "," + s.Name + "," + s.Surname + "," + s.Gender + "," + s.dob + "," + s.grade + "," + s.PhoneNumber + "," + s.Email + "," + s.Address + "," + pictureBox1.ImageLocation);



                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // closes form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addPic(); // picture fucntion to called to allow user to add desired picture
        }

        public void isempty() //validation check if user hasnt inputed any data

        {
            if (NametxtBox.Text == "" | SurnametxtBox.Text == "" | comboBox1.Text == "" | DobtxtBox.Text == "" | GradetxtBox.Text == "" | PhonetxtBox.Text == "" | EmailtxtBox.Text == "" | AddresstxtBox.Text == "" | pictureBox1.Image is null)
            {
                MessageBox.Show("Please Fill all records!!!");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            isempty();
           bool n =  isvalid_name(NametxtBox.Text);
          bool s =  isvalid_surname(SurnametxtBox.Text);
          bool d =  isvalid_DOB(DobtxtBox.Text);
          bool em =  isvalid_email(EmailtxtBox.Text);
          bool p =  isvalid_phone(PhonetxtBox.Text);
            try
            {
                if (Convert.ToInt32(GradetxtBox.Text) >= 5 | Convert.ToInt32(GradetxtBox.Text) == 0 && n == true && d == true && em == true && p == true)
                {
                    MessageBox.Show("Grade should be between 1-5");
                }
                else
                {
                    addStudent();
                    MessageBox.Show("Student has been Created");
                    this.Close();
                }
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message);
            }
           
           
        }

     
      
    }
}

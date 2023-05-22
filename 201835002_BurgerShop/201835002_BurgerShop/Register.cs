using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _201835002_BurgerShop
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPasswordConfirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void textBoxFirstname_Enter(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            if(fname.ToLower().Trim().Equals("first name"))
            {
                textBoxFirstname.Text = "";
                textBoxFirstname.ForeColor = Color.Black;
            }
        }

        private void textBoxFirstname_Leave(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            if (fname.ToLower().Trim().Equals("first name") || fname.Trim().Equals(""))
            {
                textBoxFirstname.Text = "first name";
                textBoxFirstname.ForeColor = Color.Gray;
            }
        }

        private void textBoxLastname_Enter(object sender, EventArgs e)
        {
            String lname = textBoxLastname.Text;
            if (lname.ToLower().Trim().Equals("last name"))
            {
                textBoxLastname.Text = "";
                textBoxLastname.ForeColor = Color.Black;
            }
        }
        private void textBoxLastname_Leave(object sender, EventArgs e)
        {
            String lname = textBoxLastname.Text;
            if (lname.ToLower().Trim().Equals("last name") || lname.Trim().Equals(""))
            {
                textBoxLastname.Text = "last name";
                textBoxLastname.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmail_Enter_1(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("email"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave_1(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("email") || email.Trim().Equals(""))
            {
                textBoxEmail.Text = "email";
                textBoxEmail.ForeColor = Color.Gray;
            }
        }

        private void textBoxUsername_Enter_1(object sender, EventArgs e)
        {
            String uname = textBoxUsername.Text;
            if (uname.ToLower().Trim().Equals("user name"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Leave_1(object sender, EventArgs e)
        {
            String uname = textBoxUsername.Text;
            if (uname.ToLower().Trim().Equals("user name") || uname.Trim().Equals(""))
            {
                textBoxUsername.Text = "user name";
                textBoxUsername.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter_1(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave_1(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password") || password.Trim().Equals(""))
            {
                textBoxPassword.Text = "password";
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void textBoxPasswordConfirm_Enter_1(object sender, EventArgs e)
        {
            String cpassword = textBoxPasswordConfirm.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password"))
            {
                textBoxPasswordConfirm.Text = "";
                textBoxPasswordConfirm.UseSystemPasswordChar = true;
                textBoxPasswordConfirm.ForeColor = Color.Black;
            }
        }

        private void textBoxPasswordConfirm_Leave_1(object sender, EventArgs e)
        {
            String cpassword = textBoxPasswordConfirm.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password") ||
                cpassword.ToLower().Trim().Equals("password") || 
                cpassword.Trim().Equals(""))
            {
                textBoxPasswordConfirm.Text = "confirm password";
                textBoxPasswordConfirm.UseSystemPasswordChar = false;
                textBoxPasswordConfirm.ForeColor = Color.Gray;
            }
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`( `firstname`, `lastname`, `email`, `username`, `password`) VALUES (@fn, @ln, @email, @usn ,@pass)", db.getConnection());
            
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstname.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastname.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEmail.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            db.openConnection();



            if(!checkTextBoxesValues())
            {
                if(textBoxPassword.Text.Equals(textBoxPasswordConfirm.Text))
                {
                    if (checkUsername())
                    {
                        MessageBox.Show("This Username Already Exist, Select A Different One","Duplicate Username", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Your Account Has Been Created", "Account Created", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ERROR");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Passwords Do Not Match","Password Error", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
        
            }
            else
            {
                MessageBox.Show("Enter Your Information First", "Empty Data",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }

 
            db.closeConnection();
        }


        public Boolean checkUsername()
        {
            DB db = new DB();
            String username = textBoxUsername.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

           
        }

        public Boolean checkTextBoxesValues()
        {
            String fname = textBoxFirstname.Text;
            String lname = textBoxLastname.Text;
            String email = textBoxEmail.Text;
            String uname = textBoxUsername.Text;
            String pass = textBoxPassword.Text;

            if(fname.Equals("first name") || lname.Equals("last name") || email.Equals("email address") || uname.Equals("user name") || pass.Equals("password"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void labelSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}

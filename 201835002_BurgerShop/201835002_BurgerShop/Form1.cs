using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _201835002_BurgerShop
{
    public partial class Form1 : Form
    {
        private MySqlConnection con = new MySqlConnection();
        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=burger_shop;userid=root;password=;";
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 0)
            {
               textBox6.Text = (Convert.ToInt16(textBox4.Text) - Convert.ToInt16(textBox5.Text)).ToString();
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if(textBox2.Text.Length > 0)
            {
                textBox3.Text = (Convert.ToInt64(textBox1.Text) * Convert.ToInt64(textBox2.Text)).ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "French Fries")
            {
                textBox1.Text = "5";
            }
            else if (comboBox1.SelectedItem.ToString() == "Nuggets")
            {
                textBox1.Text = "8";
            }
            else if (comboBox1.SelectedItem.ToString() == "Ice Cream")
            {
                textBox1.Text = "10";
            }
            else if (comboBox1.SelectedItem.ToString() == "Cheeseburger Menu")
            {
                textBox1.Text = "20";
            }
            else if (comboBox1.SelectedItem.ToString() == "Big Mac Menu")
            {
                textBox1.Text = "30";
            }
            else if (comboBox1.SelectedItem.ToString() == "Vegan Burger Menu")
            {
                textBox1.Text = "25";
            }
            else
            {
                textBox1.Text = "0";
            }
            textBox3.Text = "";
            textBox2.Text = "";
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.BlueViolet;
            radioButton2.ForeColor = System.Drawing.Color.RosyBrown;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("French Fries");
            comboBox1.Items.Add("Nuggets");
            comboBox1.Items.Add("Ice Cream");
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.RosyBrown;
            radioButton2.ForeColor = System.Drawing.Color.BlueViolet;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Cheeseburger Menu");
            comboBox1.Items.Add("Big Mac Menu");
            comboBox1.Items.Add("Vegan Burger Menu");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text);
            textBox4.Text = (Convert.ToInt16(textBox4.Text) + Convert.ToInt16(textBox3.Text)).ToString();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Selected)
                    {
                        textBox4.Text = (Convert.ToInt16(textBox4.Text) - Convert.ToInt16(dataGridView1.Rows[i].Cells[3].Value)).ToString();
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i =0; i< dataGridView1.Rows.Count; i++)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO item_tbl Values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "')", con);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfull Insert Data");
                con.Close();
            }
            dataGridView1.Rows.Clear();
            textBox4.Text = "0";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            con.Open();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this .Hide();
            LoadData LDForm = new LoadData();
            LDForm.ShowDialog();
            LDForm = null;
            this.Show();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox4.Text = "0";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void labelSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu main = new Menu();
            main.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

    
}
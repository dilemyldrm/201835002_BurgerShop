using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201835002_BurgerShop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] menu;
                menu = new string[3];

                menu[0] = "French Fries";
                menu[1] = "Nuggets";
                menu[2] = "Ice Cream";

                listBox1.Items.Add(menu[0]);
                listBox1.Items.Add(menu[1]);
                listBox1.Items.Add(menu[2]);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] product;
            product = new string[3];

            product[0] = "Cheeseburger Menu";
            product[1] = "Big Mac Menu";
            product[2] = "Vegan Burger Menu";

            listBox1.Items.Add(product[0]);
            listBox1.Items.Add(product[1]);
            listBox1.Items.Add(product[2]);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 main = new Form1();
            main.Show();
        }
    }
}

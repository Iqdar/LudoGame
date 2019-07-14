using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LudoGame
{
    public partial class Registeration : Form
    {
        public Registeration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox4.Text != "" && textBox3.Text != "" && textBox2.Text != "" ) {
                Form1 frm = new Form1(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Fill the form");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View frm = new View();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}

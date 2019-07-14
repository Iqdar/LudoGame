using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LudoGame
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string output = "";
            try
            {
                XmlTextReader reader = new XmlTextReader("C:\\Users\\Iqdar Shah\\source\\repos\\LudoGame\\Data\\ID_"+textBox1.Text+".xml");
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.LocalName.Equals("First"))
                        {
                            output = "First: " + reader.ReadString();
                        }
                        if (reader.LocalName.Equals("Second"))
                        {
                            output = output + "\nSecond: " + reader.ReadString();
                        }
                        if (reader.LocalName.Equals("Third"))
                        {
                            output = output + "\nThird: " + reader.ReadString();
                        }
                        if (reader.LocalName.Equals("Fourth"))
                        {
                            output = output + "\nFourth: " + reader.ReadString();
                        }
                    }
                }
                richTextBox1.Text = output;
            }
            catch (Exception)
            {
                MessageBox.Show("User not found!");
            }
        }
    }
}

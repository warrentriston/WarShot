using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Shot_Saver
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if(!textBox2.Text.Equals(Form1.directory))
            {
                if (!textBox2.Text.EndsWith("\\"))
                {
                    Form1.directory = textBox2.Text + "\\";
                }
                else
                {
                    Form1.directory = textBox2.Text;
                }
            }

            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.Text = Form1.directory;
        }
    }
}

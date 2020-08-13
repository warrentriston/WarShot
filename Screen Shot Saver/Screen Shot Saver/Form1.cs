using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Shot_Saver
{
    public partial class Form1 : Form
    {
        public static string directory;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text != "")
            {
                if (fileExists())
                {
                    DialogResult dialogResult = MessageBox.Show("File already exists. Do you want to overwrite ?", "Duplicate File", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if(createDirectory())
                        {
                            this.Visible = false;
                            CaptureMyScreen();
                        }
                    }
                }
                else
                {
                    if (createDirectory())
                    {
                        this.Visible = false;
                        CaptureMyScreen();
                    }
                }
            }
            else
            {
                label2.Text = "Name Required";
            }
            
            textBox1.Text = "";
            this.Visible = true;
        }

        public bool createDirectory()
        {
            try
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    return true;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Enter a valid directory path");
                return false;
            }

            return true;
        }

        public bool fileExists()
        {
            String fileName = directory + textBox1.Text + ".jpg";
            if (File.Exists(fileName))
            {
                return true;
            }

            return false;
        }

        private void CaptureMyScreen()
        {
            SendKeys.Send("{PRTSC}");
            SendKeys.Send("{PRTSC}");
            SendKeys.Send("{PRTSC}");
            SendKeys.Send("{PRTSC}");
            SendKeys.Send("{PRTSC}");
            SendKeys.Send("{PRTSC}");
            SendKeys.Send("{PRTSC}");
            SendKeys.Send("{PRTSC}");
            SendKeys.Send("{PRTSC}");
            SendKeys.Send("{PRTSC}");
            SendKeys.Send("{PRTSC}");
            SendKeys.Send("{PRTSC}");

            if (Clipboard.ContainsImage())
            {
                Image Img = Clipboard.GetImage();
                Bitmap bitmap = new Bitmap(Img);
                Bitmap bmpCrop = bitmap.Clone(new Rectangle(0, 0, Img.Width, Img.Height - 50), bitmap.PixelFormat);
                bmpCrop.Save(directory + textBox1.Text + ".jpg", ImageFormat.Jpeg);
            }
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            directory = @"C:\Images\";
        }
    }
}

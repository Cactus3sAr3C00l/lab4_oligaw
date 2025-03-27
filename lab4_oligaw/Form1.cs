using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab4_oligaw
{

    public partial class Form1: Form
    {
        int rotate = 0;

        public Form1()
        {
            InitializeComponent();
        }


        //wczytaj
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Select an Image File";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Error loading image: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //obrót
        private void button2_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load an image first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap rotatedImage = new Bitmap(pictureBox1.Image);



            if (rotate == 90) {
                rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (rotate == 180){
                rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

            }
            else if(rotate == 270)
            {
                rotatedImage.RotateFlip(RotateFlipType.Rotate270FlipNone);

            }

            pictureBox1.Image = rotatedImage;

        }

        private void radiobutton_checked(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                 rotate = 90;
  
            }
            else if (radioButton2.Checked)
            {
                rotate = 180;
            }
            else if (radioButton3.Checked)
            {

                rotate = 270;

            }



   
        }

        
    }
}


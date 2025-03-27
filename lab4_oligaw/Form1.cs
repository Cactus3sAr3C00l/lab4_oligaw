using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_oligaw
{
    public partial class Form1: Form
    {
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

        //odwroc kolory
        private void buttonInv_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = new Bitmap(pictureBox1.Image);
            Bitmap invertedImage = InvertColors(originalImage);
            pictureBox1.Image = invertedImage;

        }


        public Bitmap InvertColors(Bitmap originalImage)
        {
            Bitmap invertedImage = new Bitmap(originalImage);

            for (int x = 0; x < invertedImage.Width; x++)
            {
                for (int y = 0; y < invertedImage.Height; y++)
                {
                    Color pixelColor = invertedImage.GetPixel(x, y);

                    Color invertedColor = Color.FromArgb(
                        255 - pixelColor.R,
                        255 - pixelColor.G,
                        255 - pixelColor.B
                    );

                    invertedImage.SetPixel(x, y, invertedColor);
                }
            }

            return invertedImage;
        }

    }
}

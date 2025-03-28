﻿using System;
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

        //green
        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Proszę najpierw wczytać obraz.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap originalImage = new Bitmap(pictureBox1.Image);
            Bitmap greenImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);

                    int grayValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                    Color greenGrayColor = Color.FromArgb(pixelColor.A, grayValue, pixelColor.G, grayValue);
                    greenImage.SetPixel(x, y, greenGrayColor);
                }
            }

            pictureBox1.Image = greenImage;
        }


    }
}


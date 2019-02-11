using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace colourCoding
{
    public partial class Form1 : Form
    {
        Bitmap[] bitmap;
        Graphics[] picture;
        public Form1()
        {
            InitializeComponent();

            bitmap = new Bitmap[6];
            picture = new Graphics[6];

            for (int i = 0; i < 6; i++)
                bitmap[i] = new Bitmap(256, 256);

            pictureBox1.Image = bitmap[0];
            pictureBox2.Image = bitmap[1];
            pictureBox3.Image = bitmap[2];
            pictureBox4.Image = bitmap[3];
            pictureBox5.Image = bitmap[4];
            pictureBox6.Image = bitmap[5];
            picture[0] = Graphics.FromImage(pictureBox1.Image);
            picture[1] = Graphics.FromImage(pictureBox2.Image);
            picture[2] = Graphics.FromImage(pictureBox3.Image);
            picture[3] = Graphics.FromImage(pictureBox4.Image);
            picture[4] = Graphics.FromImage(pictureBox5.Image);
            picture[5] = Graphics.FromImage(pictureBox6.Image);

        }


        float rR = 0, rG = 0, rB = 0;


        // private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 3);


        private void button1_Click(object sender, EventArgs e)
        {
            Color tmpColor = Color.FromArgb(255, 0, 0);
            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    tmpColor = Color.FromArgb(0, i, j);
                    pen1.Color = tmpColor;
                    picture[0].DrawLine(pen1, i, j, i + 1, j + 1);

                }


            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    tmpColor = Color.FromArgb(255, i, j);
                    pen1.Color = tmpColor;
                    picture[1].DrawLine(pen1, i , j, i + 1, j + 1);

                }

            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    tmpColor = Color.FromArgb(i, 0, j);
                    pen1.Color = tmpColor;
                    picture[2].DrawLine(pen1, i , j, i + 1, j + 1);

                }

            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    tmpColor = Color.FromArgb(i, 255, j);
                    pen1.Color = tmpColor;
                    picture[3].DrawLine(pen1, i, j, i + 1, j + 1);

                }

          
            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    tmpColor = Color.FromArgb(i, j, 0);
                    pen1.Color = tmpColor;
                    picture[4].DrawLine(pen1, i, j, i + 1 , j + 1 );

                }
            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    tmpColor = Color.FromArgb(i, j, 255);
                    pen1.Color = tmpColor;
                    picture[5].DrawLine(pen1, i, j, i + 1 , j + 1);

                }
            pictureBox1.Refresh();
            pictureBox2.Refresh();
            pictureBox3.Refresh();
            pictureBox4.Refresh();
            pictureBox5.Refresh();
            pictureBox6.Refresh();

        }

       /* private void HSV(int x, int y)
        {
            Color pixel = bitmapa.GetPixel(x, y);

            float R = (float)System.Convert.ToDouble(pixel.R);
            float G = (float)System.Convert.ToDouble(pixel.G);
            float B = (float)System.Convert.ToDouble(pixel.B);

            float var_R = (R / 255); // RGB from 0 to 255
            float var_G = (G / 255);
            float var_B = (B / 255);

            float var_Min = min(var_R, var_G, var_B); // Min. value of RGB
            float var_Max = max(var_R, var_G, var_B); // Max. value of RGB
            float del_Max = var_Max - var_Min; // Delta RGB value

            float V = var_Max;

            float H = 0;
            float S;
            if (del_Max == 0) // This is a gray, no chroma...
            {
                H = 0; // HSV results from 0 to 1
                S = 0;
            }
            else // Chromatic data...
            {
                S = del_Max / var_Max;

                float del_R = (((var_Max - var_R) / 6) + (del_Max / 2)) / del_Max;
                float del_G = (((var_Max - var_G) / 6) + (del_Max / 2)) / del_Max;
                float del_B = (((var_Max - var_B) / 6) + (del_Max / 2)) / del_Max;

                if (var_R == var_Max)
                    H = del_B - del_G;
                else if (var_G == var_Max)
                    H = (1 / 3) + del_R - del_B;
                else if (var_B == var_Max)
                    H = (2 / 3) + del_G - del_R;

                if (H < 0)
                    H += 1;
                if (H > 1)
                    H -= 1;
            }
            textBox7.Text = System.Convert.ToString(H);
            textBox8.Text = System.Convert.ToString(S);
            textBox9.Text = System.Convert.ToString(V);

        }

        private void RGB(int x, int y)
        {
            Color pixel = bitmapa.GetPixel(x, y);

            int R = System.Convert.ToInt32(pixel.R);
            int G = System.Convert.ToInt32(pixel.G);
            int B = System.Convert.ToInt32(pixel.B);

            textBox1.Text = System.Convert.ToString(R);
            textBox2.Text = System.Convert.ToString(G);
            textBox3.Text = System.Convert.ToString(B);


        }

        private void CMY(int x, int y)
        {
            //Color pixel = bitmapa.GetPixel(Cursor.Position.X, Cursor.Position.Y);
            Color pixel = bitmapa.GetPixel(x, y);

            float R = (float)System.Convert.ToDouble(pixel.R);
            float G = (float)System.Convert.ToDouble(pixel.G);
            float B = (float)System.Convert.ToDouble(pixel.B);

            float C = 1 - (R / 255);
            float M = 1 - (G / 255);
            float Y = 1 - (B / 255);

            textBox4.Text = System.Convert.ToString(C);
            textBox5.Text = System.Convert.ToString(M);
            textBox6.Text = System.Convert.ToString(Y);


        }


        private float min(float a, float b, float c)
        {
            if (a < b)
            {
                if (a < c)
                    return a;
                else
                    return c;
            }
            else if (b < c)
                return b;
            else
                return c;
        }

        private float max(float a, float b, float c)
        {
            if (a > b)
            {
                if (a > c)
                    return a;
                else
                    return c;
            }
            else if (b > c)
                return b;
            else
                return c;
        }*/
    

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

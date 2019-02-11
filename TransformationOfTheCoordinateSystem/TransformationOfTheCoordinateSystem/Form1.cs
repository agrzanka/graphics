using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformationOfTheCoordinateSystem
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics graphics;
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.CornflowerBlue);
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Red, 2);
        private System.Drawing.Pen pen2 = new System.Drawing.Pen(Color.Black, 2);
        private System.Drawing.Pen pen3 = new System.Drawing.Pen(Color.BlanchedAlmond, 2);
        Point p1, p2;

        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
        }
//================================================== ALGORYTHMS ================================================================
//-------------------------------------------------TRANSLATION ---------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            p1.X = (int)Double.Parse(textBox1.Text);
            p1.Y = (int)Double.Parse(textBox2.Text);
            p2.X = (int)Double.Parse(textBox3.Text);
            p2.Y = (int)Double.Parse(textBox4.Text);

            graphics.DrawLine(pen, p1, p2);

            Point nSP=new Point((int)Double.Parse(textBox5.Text),(int)Double.Parse(textBox6.Text));

            Point point1 =Translation(p1, nSP);
            Point point2 = Translation(p2, nSP);

            graphics.DrawLine(pen1, point1, point2);

            MessageBox.Show("( "+ p1+ " , "+ p2+" )    =>    ( "+point1+" , "+point2+" ) ");
        }
//-------------------------------------------------CALIBRATION ----------------------------------------------------------------

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            p1.X = (int)Double.Parse(textBox1.Text);
            p1.Y = (int)Double.Parse(textBox2.Text);
            p2.X = (int)Double.Parse(textBox3.Text);
            p2.Y = (int)Double.Parse(textBox4.Text);

            graphics.DrawLine(pen, p1, p2);

            int scaleX = (int)Double.Parse(textBox7.Text);
            int scaleY = (int)Double.Parse(textBox8.Text);

            Point point1 = Calibration(p1, scaleX, scaleY);
            Point point2 = Calibration(p2, scaleX, scaleY);

            graphics.DrawLine(pen2, point1, point2);

            MessageBox.Show("( " + p1 + " , " + p2 + " )    =>    ( " + point1 + " , " + point2 + " ) ");

        }


//------------------------------------------------- ROTATION ------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            p1.X = (int)Double.Parse(textBox1.Text);
            p1.Y = (int)Double.Parse(textBox2.Text);
            p2.X = (int)Double.Parse(textBox3.Text);
            p2.Y = (int)Double.Parse(textBox4.Text);

            graphics.DrawLine(pen, p1, p2);

            double phi = Double.Parse(textBox9.Text);

            Point point1 = Rotation(p1, phi);
            Point point2 = Rotation(p2, phi);

            graphics.DrawLine(pen3, point1, point2);

            MessageBox.Show("( " + p1 + " , " + p2 + " )    =>    ( " + point1 + " , " + point2 + " ) ");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

//=================================================== FUNCTIONS ==================================================================

        Point Translation(Point p, Point newStartPoint)
        {
            int[,] matrixT= { { 1, 0, newStartPoint.X }, { 0, 1, newStartPoint.Y }, { 0, 0, 1 } };
            int[] result = { 0, 0, 0 };
            for (int i=0; i<3;i++)
            {
                result[i] = matrixT[i, 0] * p.X + matrixT[i, 1] * p.Y + matrixT[i, 2];
            }
            Point output=new Point(result[0],result[1]);
            return output;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        Point Calibration(Point p, int scaleX, int scaleY)
        {
            int[,] matrixS = { { scaleX, 0, 0 }, { 0, scaleY, 0 }, { 0, 0, 1 } };
            int[] result = { 0, 0, 0 };

            for (int i=0;i<3;i++)
            {
                result[i] = matrixS[i, 0] * p.X + matrixS[i, 1] * p.Y + matrixS[i, 2];
            }
            Point output = new Point(result[0], result[1]);
            return output;
        }

        Point Rotation(Point p, double phi)
        {
            double[,] matrixR = { { Math.Cos(phi), Math.Sin(phi), 0 }, { -Math.Sin(phi), Math.Cos(phi), 0 }, { 0, 0, 1 } };
            double[] result = { 0, 0, 0 };

            for (int i=0;i<3;i++)
            {
                result[i] = matrixR[i, 0] * p.X + matrixR[i, 1] * p.Y + matrixR[i, 2];
            }

            Point output = new Point((int)result[0], (int)result[1]);
            return output;
        }
    }
}

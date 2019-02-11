using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointInPolygon
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics graphics;
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.CornflowerBlue, 2);
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Chartreuse, 2);
        private System.Drawing.Pen pen2 = new System.Drawing.Pen(Color.DarkSalmon, 2);
        private System.Drawing.Pen pen3 = new System.Drawing.Pen(Color.MistyRose, 2);
        private System.Drawing.Pen pen4 = new System.Drawing.Pen(Color.SeaGreen, 2);
        private System.Drawing.Pen pen5 = new System.Drawing.Pen(Color.PapayaWhip, 4);

        Point p, q, r,a,b;

        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
        }

//======================================== ALGORYTHMS ============================================================
//---------------------------------which side of the line? ------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            p.X = (int)Double.Parse(textBox1.Text);
            p.Y = (int)Double.Parse(textBox2.Text);
            q.X = (int)Double.Parse(textBox3.Text);
            q.Y = (int)Double.Parse(textBox4.Text);
            graphics.DrawLine(pen, p, q);

            r.X= (int)Double.Parse(textBox5.Text);
            r.Y= (int)Double.Parse(textBox6.Text);
            graphics.DrawLine(pen1, p, r);
            graphics.DrawEllipse(pen2, r.X, r.Y, 3,3);

            double detpqr = det(p, q, r);

            if (detpqr>0)
                MessageBox.Show("LEFT SIDE");
            else if (detpqr<0)
                MessageBox.Show("RIGHT SIDE");
            else
                MessageBox.Show("COLLINEAR");
        }
//------------------------------------- both points on the same side? -------------------------------------------

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            p.X = (int)Double.Parse(textBox1.Text);
            p.Y = (int)Double.Parse(textBox2.Text);
            q.X = (int)Double.Parse(textBox3.Text);
            q.Y = (int)Double.Parse(textBox4.Text);
            graphics.DrawLine(pen, p, q);

            a.X = (int)Double.Parse(textBox7.Text);
            a.Y = (int)Double.Parse(textBox8.Text);
            graphics.DrawLine(pen1, p, a);
            graphics.DrawEllipse(pen2, a.X, a.Y, 3, 3);
            b.X = (int)Double.Parse(textBox9.Text);
            b.Y = (int)Double.Parse(textBox10.Text);
            graphics.DrawLine(pen3, p, b);
            graphics.DrawEllipse(pen4, b.X, b.Y, 3, 3);

            if ((det(p,q,a)>0)&&(det(p,q,b)>0))
                MessageBox.Show("SAME SIDE: LEFT");
            else if((det(p, q, a) < 0) && (det(p, q, b) < 0))
                MessageBox.Show("SAME SIDE: LEFT");
            else if (det(p, q, a) == 0 && det(p, q, b) == 0)
                MessageBox.Show("BOTH ARE COLLINEAR");
            else
                MessageBox.Show("DIFFERENT SIDES");
        }

//------------------------ belonging to a section -------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            p.X = (int)Double.Parse(textBox1.Text);
            p.Y = (int)Double.Parse(textBox2.Text);
            q.X = (int)Double.Parse(textBox3.Text);
            q.Y = (int)Double.Parse(textBox4.Text);
            graphics.DrawLine(pen, p, q);
            graphics.DrawEllipse(pen5, p.X, p.Y, 2, 2);
            graphics.DrawEllipse(pen5, q.X, q.Y, 2, 2);

            r.X = (int)Double.Parse(textBox5.Text);
            r.Y = (int)Double.Parse(textBox6.Text);
            graphics.DrawLine(pen1, p, r);
            graphics.DrawEllipse(pen2, r.X, r.Y, 3, 3);

            double detpqr = det(p, q, r);

            if(detpqr==0)
            {
                bool xOK = false;
                bool yOK = false;

                if (p.X <= q.X)
                {
                    if (p.X <= r.X && r.X <= q.X)
                        xOK = true;
                }
                else
                {
                    if (q.X<=r.X&&r.X<=p.X)
                        xOK = true;
                }

                if (p.Y <= q.Y)
                {
                    if(p.Y<=r.Y&&r.Y<=q.Y)
                        yOK = true;
                }
                else
                {
                    if (q.Y <= r.Y && r.Y <= p.Y)
                        yOK = true;
                }

                if (xOK==true&&yOK==true)
                    MessageBox.Show("point belongs to a segment");
                else
                    MessageBox.Show("point does not belong to a segment");
            }
            else
                MessageBox.Show("point does not belong to a segment");
        }
//---------------------------- intersecting -------------------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            p.X = (int)Double.Parse(textBox1.Text);
            p.Y = (int)Double.Parse(textBox2.Text);
            q.X = (int)Double.Parse(textBox3.Text);
            q.Y = (int)Double.Parse(textBox4.Text);
            graphics.DrawLine(pen, p, q);

            a.X = (int)Double.Parse(textBox7.Text);
            a.Y = (int)Double.Parse(textBox8.Text);
            b.X = (int)Double.Parse(textBox9.Text);
            b.Y = (int)Double.Parse(textBox10.Text);
            graphics.DrawLine(pen3, a, b);
            graphics.DrawEllipse(pen2, a.X, a.Y, 3, 3);
            graphics.DrawEllipse(pen4, b.X, b.Y, 3, 3);

            if (intersecting(p,q,a,b)==true)
                MessageBox.Show("sectors are intersecting");
            else
                MessageBox.Show("sectors are not intersecting");
        }

//-------------------------------- refresh the picture box ---------------------------------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }



//========================================= FUNCTIONS =============================================================

        double det(Point p, Point q, Point r)
        {
            double output = p.X * q.Y + q.X * r.Y + r.X * p.Y - q.Y * r.X - r.Y * p.X - p.Y * q.X;
            return output;
        }

        bool intersecting (Point p, Point q, Point a, Point b)
        {
            if ((Math.Sign(det(p, q, a)) != Math.Sign(det(p, q, b))) && ((Math.Sign(det(a, b, p)) != Math.Sign(det(a, b, q)))))
                return true;
            if ((p.X <= q.X) && (p.Y <= q.Y))
            {
                if (Math.Sign(det(p, q, a)) == 0 && ((p.X < a.X && a.X < q.X) && (p.Y < a.Y && a.Y < q.Y)))
                    return true;
                else if (Math.Sign(det(p, q, b)) == 0 && ((p.X < b.X && b.X < q.X) && (p.Y < b.Y && b.Y < q.Y)))
                    return true;
                else
                    return false;
            }
            else if (a.X <= b.X && a.Y <= b.Y)
            {
                if (det(a, b, p) == 0 && ((a.X < p.X && p.X < b.X) && (a.Y < p.Y && p.Y < b.Y)))
                    return true;
                else if (det(a, b, q) == 0 && ((a.X < q.X && q.X < b.X) && (a.Y < q.Y && q.Y < b.Y)))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}

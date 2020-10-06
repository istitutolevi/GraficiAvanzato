using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;

namespace GraficiAvanzato
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /*
        private void btnDisegna_Click(object sender, EventArgs e)
        {
            double minX = double.Parse(txtMinX.Text);
            double maxX = double.Parse(txtMaxX.Text);

            double stepX = (maxX - minX) / pct.Width;

            double minY;
            double maxY;


            CalcolaMinMaxY(minX, maxX, stepX, out minY, out maxY);

            txtMinY.Text = minY.ToString();
            txtMaxY.Text = maxY.ToString();

            double scaleX = (maxX - minX) / pct.Width;
            double scaleY = (maxY - minY) / pct.Height;

            Pen pen = new Pen(Color.Blue);
            Graphics graphics = pct.CreateGraphics();
            for (double x = minX; x <= maxX; x += stepX)
            {
                double y = F(x);

                double cX = (x - minX) / scaleX;
                double cY = (y - minY) / scaleY;

                graphics.DrawRectangle(pen, (float)cX, (float)cY, 1, 1);
            }
            graphics.Dispose();

        }
        */


        private void btnDisegna_Click(object sender, EventArgs e)
        {
            double minX = double.Parse(txtMinX.Text);
            double maxX = double.Parse(txtMaxX.Text);

            double stepX = (maxX - minX) / pct.Width;

            double minY;
            double maxY;


            CalcolaMinMaxY(minX, maxX, stepX, out minY, out maxY);

            txtMinY.Text = minY.ToString();
            txtMaxY.Text = maxY.ToString();

            double scaleX = (maxX - minX) / pct.Width;
            double scaleY = (maxY - minY) / pct.Height;

            Pen pen = new Pen(Color.Blue);
            Graphics graphics = pct.CreateGraphics();

            double oldX = minX;
            double oldY = F(minX);

            for (double x = minX; x <= maxX; x += stepX)
            {
                double y = F(x);

                double cX = (x - minX) / scaleX;
                double cY = (y - minY) / scaleY;

                double cOldX = (oldX - minX) / scaleX;
                double cOldY = (oldY - minY) / scaleY;

                graphics.DrawLine(pen, (float)cOldX, (float)cOldY, (float)cX, (float)cY);

                oldX = x;
                oldY = y;
            }
            graphics.Dispose();

        }


        private void CalcolaMinMaxY(double minX, double maxX, double stepX, out double minY, out double maxY)
        {
            minY = F(minX);
            maxY = F(minX);

            for (double x = minX; x <= maxX; x += stepX)
            {
                double y = F(x);
                if (y < minY)
                    minY = y;
                if (y > maxY)
                    maxY = y;
            }
        }


        private double F(double x)
        {
            return x * Math.Sin(x);
        }

    }
}

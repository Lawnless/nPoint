using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nPoint
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        int x = -1;
        int y = -1;
        bool moving = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            label3.Text = "Width: " + panel1.Width.ToString() + "px";
            label4.Text = "Height: " + panel1.Height.ToString() + "px";
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            label1.Text = "X: " + x.ToString();
            label2.Text = "Y: " + y.ToString();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
                label1.Text = "X: " + x.ToString();
                label2.Text = "Y: " + y.ToString();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            y = -1;
            x = -1;
            label1.Text = "X: " + x.ToString();
            label2.Text = "Y: " + y.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.White, 10);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            // int newHeight = 65;
            // panel2.MaximumSize = new Size(panel1.Width, newHeight);
            // panel2.Size = new Size(panel1.Width, newHeight);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black, 5);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("File saved as PNG!");
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}

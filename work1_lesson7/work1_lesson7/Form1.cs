using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work1_lesson7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Graphics graphics;
        //double th1 = 30 * Math.PI / 180;
        //double th2 = 20 * Math.PI / 180;
        //double per1 = double.Parse(textBox3.Text);
       // double per2 = 0.7;

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, double.Parse(textBox3.Text) * leng, th + double.Parse(textBox5.Text)*Math.PI/180);
            drawCayleyTree(n - 1, x1, y1, double.Parse(textBox4.Text) * leng, th - double.Parse(textBox6.Text) * Math.PI / 180);
        }

        void drawLine(double x0,double y0, double x1,double y1)
        {
            // string pen = textBox7.Text;
            Pen[] pens= {Pens.Black,Pens.Blue,Pens.Red,Pens.Yellow ,Pens.Green};
            char[] text = comboBox1.Text.ToCharArray();
            int index = Int32.Parse(text[0].ToString())-1;
            graphics.DrawLine(pens[index], (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(graphics!=null)
                graphics.Clear(BackColor);
            if (graphics == null)
                graphics = panel2.CreateGraphics();
            try
            {
                int x = panel2.Width;
                int y = panel2.Height;
                drawCayleyTree(Int32.Parse(textBox1.Text), x/2, y/2, Int32.Parse(textBox2.Text), -Math.PI / 2);
            }
            catch (FormatException)
            {
                Console.WriteLine("格式异常");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
   
        }
    }
}

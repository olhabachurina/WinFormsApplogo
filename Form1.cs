
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;




namespace WinFormsApplogo
{
    public partial class Form1 : Form
    {
        private Color[] outlineColors = { Color.Yellow, Color.Red };
        private int currentColorIndex = 0;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            timer.Interval = 500; 
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        void Timer_Tick (object sender, EventArgs e)
        {
            currentColorIndex = (currentColorIndex + 1) % outlineColors.Length;
            this.Invalidate();
        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush textBrush = new SolidBrush(Color.Orange);
            Pen outlinePen = new Pen(textBrush, 5);
            Font textFont = new Font("Algerian", 60, FontStyle.Bold);
            string companyText = "BestOil";
            SizeF textSize = g.MeasureString(companyText, textFont);
            float x = (this.Width - textSize.Width) / 2;
            float y = (this.Height - textSize.Height) / 2;

            // Рисуем окантовку текста
            g.DrawString(companyText, textFont, textBrush, x, y);
            g.DrawString(companyText, textFont, outlinePen.Brush, x - 2, y);
            g.DrawString(companyText, textFont, outlinePen.Brush, x + 2, y);
            g.DrawString(companyText, textFont, outlinePen.Brush, x, y - 2);
            g.DrawString(companyText, textFont, outlinePen.Brush, x, y + 2);
            g.Dispose();  
        }
    }
}
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    System.Data;
    System.Drawing;
    System.IO;
    System.Linq;
    System.Text;
    System.Threading.Tasks;
    System.Windows.Forms;
    namespace so
    {
    public partial class Form1 : Form
    {
        Image image;
        public Form1()
        {
            image = Image.FromFile("imagen.png");
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            BufferedGraphicsContext bgc = BufferedGraphicsManager.Current;
            BufferedGraphics bg = bgc.Allocate(gr,this.ClientRectangle);
            //before drawing the image clean the background with the current form's Backcolor
            bg.Graphics.Clear(this.BackColor);
            //use any overload of drawImage, the best for your project
            bg.Graphics.DrawImage(image,0,0);
            bg.Render(gr);
        }
    }
    }

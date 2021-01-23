    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Random_Terrain_Generator
    {
        public partial class Form1 : Form
        {
            Graphics fg;
            Engine e;
            public Form1()
            {
                InitializeComponent();
                e = new Engine(100, 100);
                e.Color3(Color.Blue);
                e.fRect(new Rectangle(0,0,50,50));
                fg = this.CreateGraphics();
            }
            protected override void OnPaint(PaintEventArgs pe)
            {
                // Call the OnPaint method of the base class.
                base.OnPaint(pe);
                fg.DrawImage(e.getBuffer(), 1, 1, 100, 100);
            }
        }
        public class Engine
        {
            Color fillColor;
            Bitmap buffer;
            Graphics bufferGraphics;
            public Engine(int bufferWidth, int bufferHeight)
            {
                buffer = new Bitmap(bufferWidth, bufferHeight);
                bufferGraphics = Graphics.FromImage(buffer);
            }
            public void fRect(Rectangle r)
            {
                bufferGraphics.FillRectangle(new SolidBrush(fillColor), r);
            }
            public void rect(Rectangle r)
            {
                bufferGraphics.DrawRectangle(new Pen(fillColor), r);
            }
            public void Color3(Color c)
            {
                fillColor = c;
            }
            public Bitmap getBuffer()
            {
                return buffer;
            }
        }
    }

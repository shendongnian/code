    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        private readonly Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            this.graphics = this.CreateGraphics();
            
            this.Load += (s, e) =>
            {
                foreach (var color in Enum.GetValues(typeof(KnownColor)))
                    this.UserColors.Items.Add(color);
            };
        }
        /// <summary>
        /// Painting (left button use changed color, right-white to erase)
        /// </summary>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.graphics.DrawLine(
                    new Pen(
                        Color.FromKnownColor(
                            (KnownColor)Enum.Parse(typeof(KnownColor),
                            this.UserColors.SelectedItem.ToString()))),
                    e.X,
                    e.Y,
                    e.X + 1,
                    e.Y + 1);
            if (e.Button == MouseButtons.Right)
                this.graphics.DrawLine(
                    Pens.White,
                    e.X,
                    e.Y,
                    e.X + 1,
                    e.Y + 1);
        }
    }

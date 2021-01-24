    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int Angle;
        private Image Art; // you may need to resample larger images to a smaller image dynamically!
        private int AngleStep = 20;
        private System.Drawing.Drawing2D.GraphicsPath Vinyl = new System.Drawing.Drawing2D.GraphicsPath();
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 50;
            Art = Properties.Resources.AlbumArt2; // image as embedded resource (or from somewhere else)
            // larger circle with the center cut out: (like a vinyl record)
            Vinyl.AddEllipse(pictureBox1.ClientRectangle);
            Rectangle rc = new Rectangle(pictureBox1.Width / 2, pictureBox1.Height / 2, 1, 1);
            rc.Inflate(10, 10);
            Vinyl.AddEllipse(rc);
            pictureBox1.Paint += PictureBox1_Paint;
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.SetClip(Vinyl);
            G.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2); // move to the center
            G.RotateTransform(Angle); // rotate to the current angle
            G.DrawImage(Art, new Point(-(Art.Width / 2), -(Art.Height / 2))); // draw the image centered
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Angle = Angle + AngleStep;
            if (Angle >= 360)
            {
                Angle = Angle - 360;
            }
            pictureBox1.Refresh();
        }
    }

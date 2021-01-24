    public partial class Form1 : Form
    {
        private PictureBox pictureBox2;
        public Form1()
        {
            InitializeComponent();
            pictureBox2 = new PictureBox();
            pictureBox2.Size = ClientSize;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Click += Form1_Click;
            pictureBox2.Click += Form1_Click;
            Controls.Add(pictureBox2);
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            var batch = "hello there!";
            Bitmap batchCode = new Bitmap(1000, 1000);
            var batch1 = new RectangleF(150, 150, 850, 850);
            using (Graphics g = Graphics.FromImage(batchCode))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.DrawString(batch, new Font("Arial", 40), Brushes.Black, batch1);
            }
            pictureBox2.Image = batchCode;
        }
    }

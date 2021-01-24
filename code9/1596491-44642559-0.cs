    public partial class Form1 : Form
    {
        private int scrollSpeed = 10;
        Timer timer = new Timer();
        private PictureBox backgroundPictureBox;
        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 1000;
            Height = 1000;
            backgroundPictureBox = new PictureBox
            {
                BackgroundImageLayout = ImageLayout.Stretch,
                Height = this.Height,
                Image = Image.FromFile(@"f:\Public\Temp\tmp.png"),
                Left = 0,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = true,
                Width = this.Width * 2
            };
            Controls.Add(backgroundPictureBox);
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (backgroundPictureBox.Left < (Width * -1))
            {
                backgroundPictureBox.Left = 0;
            }
            else
            {
                backgroundPictureBox.Left -= scrollSpeed;
            }
        }
    }

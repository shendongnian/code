    public Form1()
    {
        PictureBox pictureBox1 = new PictureBox();
    
        pictureBox1.Image = Image.FromFile(@"C:\\obrazki\bat2.jpg");
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.Visible = true;
    
        pictureBox1.Left = 100;
        pictureBox1.Top = 100;
        // missing line
        Controls.Add(pictureBox1);
    
        InitializeComponent();
    }

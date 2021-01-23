    public Form1()
    {
        InitializeComponent();
        pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
        pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
    }

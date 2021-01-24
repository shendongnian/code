    public Form1()
    {
        InitializeComponent();
        pictureBox1.Paint += PictureBox1_Paint;
    }
    private void PictureBox1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(Color.Aqua);
        e.Graphics.DrawRectangle(Pens.Black, 10, 10, 10, 10);
    }

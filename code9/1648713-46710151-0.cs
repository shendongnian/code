    public Form1()
    {
        InitializeComponent();
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        Draw();
    }
    
    private void Draw()
    {
        Graphics g = pictureBox.CreateGraphics();
        g.Clear(Color.White);
        Pen p = new Pen(Color.Black, 1);
        g.DrawRectangle(p, 0, 0, 50, 50);
    }

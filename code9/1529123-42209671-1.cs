    public Form1()
    {
        InitializeComponent();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        pictureBox1.Invalidate();
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        // Compute hand positions.
        // ...
        // Clear the previous drawing.
        e.Graphics.Clear(Color.White);
        // Create pen, draw the hands.
        using (Pen blackPen = new Pen(Color.Black, 3))
        {
            e.Graphics.DrawLine(blackPen, point1hr, point2hr);
            e.Graphics.DrawLine(blackPen, point1min, point2min);
            e.Graphics.DrawLine(blackPen, point1sec, point2sec);
        }
    }

    private int x = 0;
    public int X
    {
        get
        {
            return x;
        }
        set
        {
            x = value;
            // Cause the form to be redrawn.
            this.Invalidate();
        }
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(Color.Black);
        // Only draw the line if x == 1.
        if (x == 1)
        {
            e.Graphics.DrawLine(Pens.White, 108, 272, 153, 160);
        }
    }

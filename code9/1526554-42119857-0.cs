    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(Color.White);
        // Only draw the line if x == 1.
        if (x == 1)
        {
            e.Graphics.DrawLine(Pens.White, 108, 272, 153, 160);
        }
    }

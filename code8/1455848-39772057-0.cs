    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        // draw here
    }
    private void gameTimer_Tick(object sender, EventArgs e) 
    {
       this.Invalidate(); // optionally, provide the area to invalidate for better performance
    }

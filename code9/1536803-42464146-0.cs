    private void drawAxes(Graphics g, Rectangle rect)
    {
        Pen lapiz = new Pen(Color.Black);
        //Dibujo de ejes X y Y
        g.DrawLine(lapiz, 20, rect.Height - 20, rect.Width - 20, rect.Height - 20);
        g.DrawLine(lapiz, 20, rect.Height - 20, 20, 20);
        g.DrawString("X", Font, Brushes.Black, new Point(rect.Width - 17 , rect.Height - 27));
        g.DrawString("Y", Font, Brushes.Black, new Point(14, 5));
    }
    
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        drawAxes(e.Graphics, pictureBox1.Bounds);
    }
    
    private void pictureBox1_Resize(object sender, EventArgs e)
    {
        pictureBox1.Invalidate();
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            points.Add(e.Location);
            pictureBox1.Invalidate();
        }
    }
     
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {enter code here
        if (points.Count > 1)
           e.Graphics.DrawLines(Pens.Black, points.ToArray());
    }

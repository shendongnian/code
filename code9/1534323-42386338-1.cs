    //global variables
    private Point? p1;
    private Point? p2;
    private int counter = 0;
    private void pictureBox1_Click(object sender, EventArgs e)
    {
        if (radioButtonDrawLine.Checked)
        {
            if (counter == 0)
            {
                p1 = pictureBox1.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                counter++;
            }
            else
            {
                p2 = pictureBox1.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                pictureBox1.Refresh();
                counter = 0;
            }
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (p1.HasValue && p2.HasValue)
        {
            e.Graphics.DrawLine(Pens.Black, p1.Value.X, p1.Value.Y, p2.Value.X, p2.Value.Y);
        }
    }

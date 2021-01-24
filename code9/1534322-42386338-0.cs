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
                p1 = new Point(Cursor.Position.X, Cursor.Position.Y);
                counter++;
            }
            else
            {
                p2 = new Point(Cursor.Position.X, Cursor.Position.Y);
                pictureBox1.Refresh();
                counter = 0;
            }
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (p1.HasValue && p2.HasValue)
        {
            var relativeP1 = pictureBox1.PointToClient(p1.Value);
            var relativeP2 = pictureBox1.PointToClient(p2.Value);
            e.Graphics.DrawLine(Pens.Black, relativeP1.X, relativeP1.Y, relativeP2.X, relativeP2.Y);
        }
    }

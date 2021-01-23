    if (e.Button == System.Windows.Forms.MouseButtons.Left)
    {
        pictureBox1.Image = originalImage.Clone();
        Graphics g = Graphics.FromImage(pictureBox1.Image);
        if (i <100000000 )
        {
            foreach(Line l in lines)
            {
                g.DrawLine(Pens.Black, l.StartingPoint, l.EndingPoint);
            }     
        }
        current.EndingPoint = new Point(e.X, e.Y);
        g.DrawLine(Pens.Black, current.StartingPoint, current.EndingPoint);
    }
    i++;

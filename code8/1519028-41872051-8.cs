    if (e.KeyCode == Keys.Back)
    { 
        if ( lines.RemoveAt(lines.Count - 1) )
        {
            pictureBox1.Image = originalImage.Clone();
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            foreach(Line l in lines)
            {
                g.DrawLine(Pens.Black, l.StartingPoint, l.EndingPoint);
            }  
        }
    }

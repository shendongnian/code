    private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        Point src = e.Location;
        PointF ratio = new PointF((float)src.X / pictureBox1.Width, (float)src.Y / pictureBox1.Height);
        Point origin = new Point((int)(label1.Width * ratio.X), (int)(label1.Height * ratio.Y));
        label1.Left = src.X - origin.X;
        label1.Top = src.Y - origin.Y;
        
        Point pos2 = new Point((int)(ratio.X * pictureBox2.Width), (int)(ratio.Y * pictureBox2.Height));
        label2.Left = pos2.X + pictureBox2.Left - origin.X;
        label2.Top = pos2.Y + pictureBox2.Top - origin.Y;
        Point pos3 = new Point((int)(ratio.X * pictureBox3.Width), (int)(ratio.Y * pictureBox3.Height));
        label3.Left = pos3.X + pictureBox3.Left - origin.X;
        label3.Top = pos3.Y + pictureBox3.Top - origin.Y;
        Point pos4 = new Point((int)(ratio.X * pictureBox4.Width), (int)(ratio.Y * pictureBox4.Height));
        label4.Left = pos4.X + pictureBox4.Left - origin.X;
        label4.Top = pos4.Y + pictureBox4.Top - origin.Y;
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        if (isMoving)
        {
            // You event don't need this line
            //lines.Add(Tuple.Create(mouseDownPosition, mouseMovePosition));
            if (pictureBox1.Image != null)
            {
                using (var g = Graphics.FromImage(pictureBox1.Image))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.DrawLine(pen, mouseDownPosition, mouseMovePosition);
                }
                pictureBox2.Image = pictureBox1.Image;
            }
        }
        isMoving = false;
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (isMoving)
        {
            if ((sender as PictureBox).Image == null) e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.DrawLine(pen, mouseDownPosition, mouseMovePosition);
        }
    }
    private void pictureBox2_Paint(object sender, PaintEventArgs e)
    {
    }

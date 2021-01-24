    var rect1 = new System.Drawing.Rectangle(pictureBox1.Location, pictureBox1.Size);
    var rect2 = new System.Drawing.Rectangle(pictureBox2.Location, pictureBox2.Size);
    if (rect1.IntersectsWith(rect2))
    {
        // Here is your collision.
    }

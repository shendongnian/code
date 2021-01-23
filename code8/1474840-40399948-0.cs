    Bitmap backPage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    pictureBox1.Image = backPage;
---
    using(var g = Graphics.FromImage(backPage))
    {
        // draw
    }
    pictureBox1.Refresh();

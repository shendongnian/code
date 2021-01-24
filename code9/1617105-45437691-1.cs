    private void button1_Click(object sender, EventArgs e)
    {
        Bitmap bmp = Bitmap.FromFile(pathToTheFile);
        using(var graphics = Graphics.FromImage(bmp))
            graphics.DrawLine(Pens.Black, 0, 0, 50, 50);
        var oldImg = pictureBox1.Image;
        pictureBox1.Image = bmp;
        if(oldImg != null)
          oldImg.Dispose();
        pictureBox1.Enabled = true;
        pictureBox1.Visible = true;
        
    }

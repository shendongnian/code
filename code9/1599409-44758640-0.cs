    Image original = null;
    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        if (original == null) original = (Bitmap) pictureBox1.Image.Clone();
        pictureBox1.BackColor = Color.Transparent;
        pictureBox1.Image = SetAlpha((Bitmap)original, trackBar1.Value);
    }

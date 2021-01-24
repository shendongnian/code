    PictureBox pb = new PictureBox();
    private void buttonZ1_Click(object sender, EventArgs e)
    {
        pb.SizeMode = PictureBoxSizeMode.StretchImage;
        pb.Image = new Bitmap("C:\\Users\\user\\Desktop\\rectangle.png");
        // etc.
        // The code here doesn't change, you just remove the first "new PictureBox()" line
    }
    private void button1_Click(object sender, EventArgs e)
    {
        pb.Height = Convert.ToInt32(textBox1.Text);
        pb.Width = Convert.ToInt32(textBox2.Text);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        pictureBox1.Image = Image.FromFile(@"c:\Users\Admin\Desktop\tmp.png");
        this.Width = pictureBox1.Image.Width + splitContainer1.Panel2.Width;
        splitContainer1.SplitterDistance = pictureBox1.Image.Width;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        pictureBox1.Image = Image.FromFile(@"c:\Users\Admin\Desktop\tmp.png");
        pictureBox1.Width = pictureBox1.Image.Width;
        var prevWidthPanel2 = splitContainer1.Panel2.Width;
        splitContainer1.SplitterDistance = pictureBox1.Image.Width;
        this.Width = (this.Width - splitContainer1.Panel2.Width)+ prevWidthPanel2;
        splitContainer1.SplitterDistance = pictureBox1.Image.Width;
    }

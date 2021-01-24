    private void asdToolStripMenuItem_Click(object sender, EventArgs e)
    {
        pictureBox1.Load(textBox1.Text);
        pictureBox1.Visible = true;
        img = new Bitmap(textBox1.Text); //Add this line.
    }

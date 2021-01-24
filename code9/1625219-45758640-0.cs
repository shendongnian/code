    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
            //... 
            Bitmap newBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(newBitmap);
            g.DrawRtfText(this.richTextBox1.Rtf, this.pictureBox1.ClientRectangle);
            newBitmap.Save(@"d:\adv.jpg");
    }

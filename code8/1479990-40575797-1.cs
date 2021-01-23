    private void button1_Click(object sender, EventArgs e)
    {
        using (var bm = new Bitmap(panel1.Width, panel1.Height))
        {
            panel1.DrawToBitmap(bm, new Rectangle(0, 0, bm.Width, bm.Height));
            bm.Save(@"d:\panel.bmp", System.Drawing.Imaging.ImageFormat.Bmp); 
        }
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.FillRectangle(Brushes.Red, 0, 0, 100, 100);
        e.Graphics.FillRectangle(Brushes.Blue, 50, 50, 100, 100);
    }

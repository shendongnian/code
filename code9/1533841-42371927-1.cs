    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        float zoom =100f *  pictureBox1.ClientSize.Width / pictureBox1.Image.Width;
        string s = zoom.ToString("#.#")+ "%";
        StringFormat format = new StringFormat()
            { LineAlignment = StringAlignment.Far,
            Alignment = StringAlignment.Far };
        Rectangle bounds = pictureBox1.ClientRectangle;
        Rectangle bounds1 = pictureBox1.ClientRectangle;
        bounds1.Offset(1, 1);
        using (Font font = new Font("Consolas", 14f))
        {
            e.Graphics.DrawString(s, font, Brushes.White, bounds , format);
            e.Graphics.DrawString(s, font, Brushes.Black, bounds1 , format);
        }
    }

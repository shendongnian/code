    private void button1_Click(object sender, EventArgs e)
    {
        Size sz = panel1.ClientSize;
        // first we (optionally) create a bitmap in the original panel size:
        Rectangle rect1 = panel1.ClientRectangle;
        Bitmap bmp = new Bitmap(rect1.Width, rect1.Height);
        panel1.DrawToBitmap(bmp, rect);
        bmp.Save("D:\\rtfImage1.png", ImageFormat.Png);
        // now we create a 4x larger one:
        Rectangle rect2 = new Rectangle(0, 0, sz.Width * 4, sz.Height * 4);
        Bitmap bmp2 = new Bitmap(rect2.Width, rect2.Height);
        // we need to temporarily enlarge the panel:
        panel1.ClientSize = rect2.Size;
        // now we can let the routine draw
        panel1.DrawToBitmap(bmp2, rect2);
        // and before saving we optionally can set the dpi resolution
        bmp2.SetResolution(300, 300);
        // optionally make background transparent:
        bmp2.MakeTransparent(richTextBox1.BackColor);
        UnSemi(bmp2);  // see the link in the comment!
        // save text always as png; jpg is only for fotos!
        bmp2.Save("D:\\rtfImage2.png", ImageFormat.Png);
   
        // restore the panels size
        panel1.ClientSize = sz;
    }

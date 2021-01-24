    private void button1_Click(object sender, EventArgs e)
    {
        Bitmap bmp1 = (Bitmap) Image.FromFile(path1); 
        Bitmap bmp2 = (Bitmap) Image.FromFile(path2);
        int factor = 8;
        Size sz = bmp1.Size;
        Size szs = new Size(sz.Width / factor, sz.Height / factor);
        Bitmap bmp1s = new Bitmap(bmp1, szs);
        Bitmap bmp2s = new Bitmap(bmp2, szs);
        float avgBrightnes1 = getAvgBrightness(bmp1, 1000);
        float avgBrightnes2 = getAvgBrightness(bmp2, 1000);
        float avgB12 = (avgBrightnes1 +avgBrightnes2) / 2f;
        float deltaB1 = avgB12 - avgBrightnes1;
        float deltaB2 = avgB12 - avgBrightnes2;
        Console.WriteLine("  B1 = " + avgBrightnes1.ToString("0.000") 
                        +   "B2 = " + avgBrightnes2.ToString("0.000"));
        pictureBox1.Image = (Bitmap)bmp1;
        pictureBox2.Image = (Bitmap)bmp2;
        Rectangle r1 = new Rectangle(0, 0, sz.Width, sz.Height);
        Rectangle r2 = new Rectangle(0, sz.Height, sz.Width, sz.Height);
        Bitmap bmp12 = new Bitmap(sz.Width, sz.Height * 2);
        ColorMatrix M1 = new ColorMatrix();
        M1.Matrix40 =  M1.Matrix41 = M1.Matrix42 = deltaB1;
        ColorMatrix M2 = new ColorMatrix();
        M2.Matrix40 =  M2.Matrix41 = M2.Matrix42 = deltaB2;
        ImageAttributes iAtt = new ImageAttributes();
        using (Graphics g = Graphics.FromImage(bmp12))
        {
            iAtt.SetColorMatrix(M1, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.DrawImage(bmp1,r1, 0,0,sz.Width, sz.Height,  GraphicsUnit.Pixel, iAtt);
            iAtt.ClearColorMatrix();
            iAtt.SetColorMatrix(M2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.DrawImage(bmp2,r2, 0,0,sz.Width, sz.Height,  GraphicsUnit.Pixel, iAtt);
        }
            pictureBox3.Image = (Bitmap)bmp12;
    }
    float getAvgBrightness(Bitmap bmp, int count)
    {
        Random rnd = new Random(0);
        float b = 0f;
        for (int i = 0; i < count; i++)
        {
            b += bmp.GetPixel(rnd.Next(bmp.Width), rnd.Next(bmp.Height)).GetBrightness();
        }
        return b/count;
    }

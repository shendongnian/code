    private void crop_bttn_Click(object sender, EventArgs e)
    {
        Image crop = GetCopyImage("grayScale.jpg");
        pictureBox2.Image = crop;
        Bitmap targetBitmap = new Bitmap(pictureBox3.ClientSize.Width, 
                                        pictureBox3.ClientSize.Height);
        using (Bitmap sourceBitmap = new Bitmap(pictureBox2.Image, 
                     pictureBox2.ClientSize.Width, pictureBox2.ClientSize.Height))
        {
            using (Graphics g = Graphics.FromImage(targetBitmap))
            {
                g.DrawImage(sourceBitmap, new Rectangle(0, 0, 
                            pictureBox3.ClientSize.Width, pictureBox3.ClientSize.Height), 
                            rectCropArea, GraphicsUnit.Pixel);
            }
        }
        if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
        pictureBox3.Image = targetBitmap;
        targetBitmap.Save(somename, someFormat);
    }

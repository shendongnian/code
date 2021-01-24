    private void UpdateUI(object sender, ProgressChangedEventArgs e)
    {
        Bitmap source = m_processedImage.bitmap;
        Bitmap resized = CreateWithNewSize(source, source.Width / zoom, source.Height / zoom);
        // Save reference to old image in the control
        Image oldImg = pictureBox1.Image;
        pictureBox1.Image = resized;
        // specifically dispose old image to avoid memory usage buildup
        if (oldImg != null)
        {
            try{ oldImg.Dispose(); }
            catch { /* Ignore; won't help much to process this */ }
        }
        // Request refresh.
        pictureBox1.Invalidate();
    }

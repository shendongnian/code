    private void UpdateUI(object sender, ProgressChangedEventArgs e)
    {
        Bitmap source = m_processedImage.bitmap;
        Bitmap resized = CreateWithNewSize(source, source.Width / zoom, source.Height / zoom);
        // specifically dispose old image to avoid memory usage buildup
        if (pictureBox1.Image != null)
        {
            try{ pictureBox1.Image.Dispose(); }
            catch { /* Ignore; won't help much to process this */ }
        }
        pictureBox1.Image = resized;
        pictureBox1.Invalidate();
    }

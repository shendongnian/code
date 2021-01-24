    private void trackBarBrightness_EditValueChanged(object sender, EventArgs e)
    {
        //your current code here up to (excluding): pictureEdit.Image = bm;
        IDisposable PreviousImage = pictureEdit.Image;
        pictureEdit.Image = bm;
        PreviousImage?.Dispose();
    }

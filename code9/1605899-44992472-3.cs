    private IDisposable PreviousImage {get;set;}
    private void trackBarBrightness_EditValueChanged(object sender, EventArgs e)
    {
        //your current code here up to (excluding): pictureEdit.Image = bm;
        pictureEdit.Image = bm;
        PreviousImage?.Dispose();
        PreviousImage = bm;
    }

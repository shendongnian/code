    private void btnCaptureNewImage_Click(object sender, EventArgs e)
    {
        if (btnCaptureNewImage.Text == "Capture New Image")
        {
            VideoShow();
            btnCaptureNewImage.Text = "Take Photo";
        }
        else
        {
            FinalVideoSource.Stop();
            TakePhoto();
            btnCaptureNewImage.Text = "Capture New Image";
        }
    }

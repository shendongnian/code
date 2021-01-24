    if (fileName.Contains("pdf"))
    {
        PDFView.Visibility = Visibility.Visible;
        MediaElement.Visibility = Visibility.Collapsed;
    }
    else if (fileName.Contains("mp4"))
    {
        PDFView.Visibility = Visibility.Collapsed;
        MediaElement.Visibility = Visibility.Visible;
    }

    public void OpenFile (NSUrl fileUrl)
    {
        var docControl = UIDocumentInteractionController.FromUrl (fileUrl);
        var window = UIApplication.SharedApplication.KeyWindow;
        var subViews = window.Subviews;
        var lastView = subViews.Last ();
        var frame = lastView.Frame;
        docControl.PresentOpenInMenu (frame, lastView, true);
    }

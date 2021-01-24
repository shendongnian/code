    public void RotatePage(int page_number)
    {
        mPDFView.DocLock(true); // lock the document for editing, and stop rendering
        try
        {
            Page page = mPDFView.GetDocument().GetPage(page_number);
            page.SetRotation(Page.AddRotations(Page.Rotate.e_90, page.GetRotation()));
        }
        finally
        {
            mPDFView.DocUnlock(); resume background threads
        }
        mPDFView.UpdatePageLayout();
    }

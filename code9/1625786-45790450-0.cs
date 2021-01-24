    if (pdfDocument.IsPasswordProtected)
    {
        rootPage.NotifyUser("Document is password protected.", NotifyType.StatusMessage);
    }
    else
    {
        rootPage.NotifyUser("Document is not password protected.", NotifyType.StatusMessage);
    }

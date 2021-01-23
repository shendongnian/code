    static RadPdfViewer rViewer = new RadPdfViewer();
    static RadPrintDocument rpd = new RadPrintDocument();
    internal static bool PrintReportBlocking(string sFileName, REPORT_TYPE reportType)      
    {
        var tcs = new TaskCompletionSource<object>();
        try
        {
            rpd = new RadPrintDocument();
            rViewer = new RadPdfViewer();
            rViewer.DocumentLoaded += () => tcs.SetResult(null);
            rViewer.LoadDocument(sFileName);
            // If you really want to block, but you should probably use async/await
            tcs.Task.Wait();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

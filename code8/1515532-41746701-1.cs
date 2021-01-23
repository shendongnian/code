    static void rViewer_DocumentLoaded(object sender, EventArgs e)
    {
        are.Set();
        //Do something
    }
    static RadPdfViewer rViewer = new RadPdfViewer();
    static RadPrintDocument rpd = new RadPrintDocument();
    static AutoResetEvent are = new AutoResetEvent(false);
    internal static bool PrintReportBlocking(string sFileName, REPORT_TYPE reportType)
    {
        try
        {
            rpd = new RadPrintDocument();
            rViewer = new RadPdfViewer();
            rViewer.DocumentLoaded += rViewer_DocumentLoaded;
            rViewer.LoadDocument(sFileName);
            are.WaitOne();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

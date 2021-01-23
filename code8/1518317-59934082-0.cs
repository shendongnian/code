    private int _isRendering = 0;
    
    // Constructor code
    reportViewer.RenderingBegin += ReportViewer_RenderingBegin;
    reportViewer.RenderingComplete += ReportViewer_RenderingComplete;
    
    private void ReportViewer_RenderingComplete(object sender, RenderingCompleteEventArgs e)
    {
        _isRendering--;
    }
    
    private void ReportViewer_RenderingBegin(object sender, System.ComponentModel.CancelEventArgs e)
    {
        _isRendering++;
    }

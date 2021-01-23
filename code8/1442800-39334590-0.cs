    private bool _isClosed = false;   
    protected override void OnClosed(EventArgs e)
    {
        _isClosed = true;
        base.OnClosed(e);     
    }
    private void Log(string text)
    {
       if (_isClosed) return;
        textBoxLog.AppendText(text);
        textBoxLog.ScrollToLine(textBoxLog.LineCount - 1);
    }

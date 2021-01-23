    private void WriteLn(string text)
    {
        tbLog.Dispatcher.BeginInvoke(new Action(() =>
        {
            tbLog.Text += text + Environment.NewLine;
        }));
    }

    private static readonly object synchLock = new object();
    private void OutputMessageToLogWindow(string message)
    {
        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        {
            lock(synchLock)
            {
               outputRichTxtBox.AppendText(message);
               test.Text = message;
            }
        }));
    }

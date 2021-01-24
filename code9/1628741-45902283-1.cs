    public void Report(string Message)
    {
        if (txtLog != null)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.BeginInvoke(new MethodInvoker(() => Report(Message)));
            }
            else
            {
                lock (syncRoot)
                {
                    txtLog.AppendText(DateTime.Now.ToString("o") + " :: " + System.Threading.Thread.CurrentThread.ManagedThreadId + " :: " + Message.TrimEnd() + "\r\n");
                }
            }
        }
    }

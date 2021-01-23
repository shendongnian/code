    public void AppendTextBox(string value)
        {
            if (textLog.InvokeRequired)
            {
                try
                {
                    textLog.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                   
                }
                catch (ObjectDisposedException)
                {
                    thrIsAlive = false;
                }
            }
            else textLog.Text += value;
        }

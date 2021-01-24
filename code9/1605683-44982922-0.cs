    void Log(string msg)
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action<string>(Log), new object[] {msg});
                    return;
                }
                logBox.Text = "";
                logBox.Text += msg + Environment.NewLine;
            }

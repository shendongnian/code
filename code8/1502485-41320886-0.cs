    // class member on the form
    ConsoleAppManager cm = null;    
    private void button1_Click(object sender, EventArgs e)
    {
        // check if have an instance, to prevent starting too much
        if (cm == null)
        {
            cm = new ConsoleAppManager(@"cmd.exe");
        } else
        {
            if (cm.Running)
            {
                // still running, bail out
                return; 
            }
        }
        // subscribe to the event
        // the implementation of the ConsoleAppManager handles UI thread sync
        cm.StandartTextReceived += (s, text) =>
        {
            // it doesn't play nicely if the form
            // closes while the process is still running
            if (!this.richTextBox1.IsDisposed)
            {
                this.richTextBox1.AppendText(text);
            }
        };
        cm.ExecuteAsync(@"/c ""dir c:\*.exe /s """);
    }
    // it is very limited to end it ...
    private void Form3_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (cm != null)
        {
            // how on earth do you end that process?
            cm = null; 
        }
    }

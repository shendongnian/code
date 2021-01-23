    private void OutputHandler(object sendingProcess, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
               BeginInvoke(new MethodInvoker(() => { textBox1.Text = e.Data; }));
        }

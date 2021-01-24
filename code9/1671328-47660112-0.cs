    public static void Write(String text, Color color, TextBox textArea, Form ui)
    {
        textArea.ForeColor = color;
        var handler = new Action<string>(textArea.AppendText);
        foreach (char c in text) //Write the text
        {
            textArea.Invoke(handler, c.ToString());
            if (c == '\n')
            {
                textArea.Invoke(handler, "\n");
                Thread.Sleep(100);
            }
            Thread.Sleep(30);
        }
        textArea.Invoke(handler, "\n");
    }
    private void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        backgroundWorker1.RunWorkerAsync();
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        button1.Enabled = true;
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        Write("this is button 1", Color.Red, textBox1, this);
    }

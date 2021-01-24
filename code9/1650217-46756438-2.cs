    for (int i = 0; i < richTextBox1.Lines.Length; i++)
    {
        System.Threading.Thread.Sleep(5000);
        SendKeys.Send(richTextBox1.Lines[i] + "\r\n");
    }

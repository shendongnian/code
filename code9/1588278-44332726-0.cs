    void Run()
    {
        var getLines = new Func<object>(() => richTextBox1.Lines);
        var lines = (string[]) richTextBox1.Invoke(getLines);
        foreach (var line in lines)
        {
            Log(line, label1);
            Thread.Sleep(500);
        }
    }

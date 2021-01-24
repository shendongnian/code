    void Run(string[] lines)
    {
        foreach (var line in lines)
        {
            Log(line, label1);
            Thread.Sleep(500);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        var lines = richTextBox1.Lines;
        var th = new ThreadStart(() => Run(lines));
        var th2 = new Thread(th);
        th2.Start();
    }

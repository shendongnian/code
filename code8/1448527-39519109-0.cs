    System.Diagnostics.Stopwatch sw = new Stopwatch();
    public void button1_Click()
    {
        sw.Start;  // start the stopwatch
        // do work
        ...
        sw.Stop;  // stop the stopwatch
        // display stopwatch contents
        label1.Text = string.Format({0}, sw.Elapsed);
    }

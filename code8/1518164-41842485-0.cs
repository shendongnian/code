    static void ThreadProc(Object stateInfo) 
    {
        ??? e3 = (???)stateInfo;
        Stopwatch timer = new Stopwatch();
        timer.Start();
        List<Wire> wires = e3.Project.Wires;
        timer.Stop();
        Console.WriteLine("WPF " + wires.Count + " in " + timer.Elapsed);
    }

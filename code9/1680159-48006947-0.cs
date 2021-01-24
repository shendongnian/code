    static void Main(string[] args)
    {
        Program prog = new Program();
        Task t = prog.Print();
        t.Wait();
    }

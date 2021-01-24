    static void Main(string[] args)
    {
        using (BackgroundWorker bw = new BackgroundWorker())
        {
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();
        }
        Console.WriteLine("Press Q to exit");
        while (Console.ReadKey(true).Key!=ConsoleKey.Q){}
    }
    
    private static bool[] opened;
    private static void Bw_DoWork(object sender, DoWorkEventArgs e)
    {
        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.mp3");
        opened = new bool[files.Length];
    
        while (true)
            for (int i = 0; i < files.Length; i++)
                try
                {
                    using (var fs = File.Open(files[i], FileMode.Open, FileAccess.Read, FileShare.None))
                        opened[i] = false;
                }
                catch{ opened[i] = true; }
    }

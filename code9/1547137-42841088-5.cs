    private static async void DoFileLoad() {
        Loader loader = new Loader();
        var tasks = new List<Task<int>>();
        tasks.Add(loader.NumOfLinesinFile("C://file1.txt", 1));
        tasks.Add(loader.NumOfLinesinFile("C://file2.txt", 33));
        tasks.Add(loader.NumOfLinesinFile("C://fil3.txt", 0));
        tasks.Add(loader.NumOfLinesinFile("C://fil3.txt", 6));
        while (tasks.Count > 0) {
            var t = await Task.WhenAny(tasks);
            Console.WriteLine(t.Result);
            tasks.Remove(t);
        }
        Console.ReadKey();
        loader.Dispose();
    }

        var stats = new Dictionary<string, int>();
        string path = "C:\\", pattern = "*.txt";
        GetChildDirectories(path, pattern, stats);
        Console.WriteLine("Directory | Count");
        foreach (var key in stats.Keys)
        {
            if (stats[key] == -1)
                Console.WriteLine("Unable to access path: {0}", key);
            else
                Console.WriteLine("{0} | {1}", key, stats[key]);
        }

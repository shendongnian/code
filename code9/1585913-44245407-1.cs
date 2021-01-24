    var workspace = new DirectoryInfo("MyWorkspace");
    if (workspace.Exists)
    {
        workspace.Delete();
    }
    workspace.Create();
    var limit = 23997907;
    var buffer = new HashSet<string>();
    ulong i = 0;
    int j = 0;
    var stopWatch = Stopwatch.StartNew();
    while (i <= ulong.MaxValue)
    {
        var result = YourSuperAlgorythm(i);
        // Check the result with current results
        if (buffer.Contains(result))
        {
            throw new Exception("Failure !");
        }
        // Check the result with older results
        foreach (var file in workspace.GetFiles())
        {
            var content = new HashSet<string>(File.ReadAllText(file.FullName).Split(';'));
            if (content.Contains(result))
            {
                throw new Exception("Failure !");
            }
        }
        buffer[j] = result;
        i++;
        j++;
        if (j == arrayLimit)
        {
            stopWatch.Stop();
            Console.WriteLine("Resetting. This loop takes " + stopWatch.Elapsed.TotalMilliseconds + "ms");
            j = 0;
            var file = Path.GetRandomFileName();
            File.WriteAllText(Path.Combine(workspace.FullName, file), String.Join(";", buffer));
            buffer = new HashSet<string>();
            stopWatch.Restart();
        }
    }

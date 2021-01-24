    FileStream fs = new FileStream(@"c:\temp\OutputFile.txt", FileMode.Create);
    StreamWriter sw = new StreamWriter(fs);
    TextWriter tmp = Console.Out; // stdout since it hasn't been changed
    Console.SetOut(sw); // point to file
    var stopw = Stopwatch.StartNew();
    for (int i = 0; i < 100000; i++)
    {               
        Console.WriteLine(i); // writes to file
    }
    sw.Dispose();
    fs.Dispose();
    var toFileTotalMs = stopw.Elapsed.TotalMilliseconds;
    // Reset console to write to stdout
    Console.SetOut(tmp);
    stopw.Restart();
    for (int i = 0; i < 100000; i++)
    {
        Console.WriteLine(i); // writes to stdout
        Console.SetOut(tmp); // point to stdout (every iteration)
        Console.WriteLine(i); // writes to stdout
    }
    var toConsoleTotalMs = stopw.Elapsed.TotalMilliseconds;
    Console.WriteLine($"toFileTotalMs={toFileTotalMs}; toConsoleTotalMs={toConsoleTotalMs};");
    Console.Read(); // leaves console window open

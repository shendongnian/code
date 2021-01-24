    private static void Main(
    {
        const string fileForCheck = @"D:\Data\System\en_visual_studio_enterprise_2015_x86_x64_dvd_6850497.iso";
        Debug.Assert(File.Exists(fileForCheck));
        var watch = new Stopwatch();
        var counter = new FileBytesCounter(fileForCheck);
        watch.Start();
        var results = counter.GetByteCount();
        watch.Stop();
        counter.Dispose();
        Console.WriteLine("Results:");
        Console.WriteLine(string.Join(", ", results.Select((c, b) => $"{b} -> {c}")));
        var sumBytes = results.Sum(c => c);
        Debug.Assert((new FileInfo(fileForCheck)).Length == sumBytes);
        Console.WriteLine();
        Console.WriteLine($"file length {sumBytes}");
        Console.WriteLine($"duration {watch.Elapsed}");
    }

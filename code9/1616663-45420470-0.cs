    var di = //new DriveInfo("c");
        new
        {
            TotalSize = 255471906816L,
            AvailableFreeSpace = 125059747840L
        };
    var ps = ((di.TotalSize - di.AvailableFreeSpace) / di.TotalSize) * 100;
    Console.WriteLine(ps);  // 0
    var ps2 = (int)((((double)di.TotalSize - di.AvailableFreeSpace) / di.TotalSize) * 100d);
    Console.WriteLine(ps2);  // 51

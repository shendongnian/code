    System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
    while (sw.Elapsed <= TimeSpan.FromMinutes(5))
    {
        if (Name == null)
        {
            CheckName = false;
            break;
        }
    }
    
    sw.Stop();

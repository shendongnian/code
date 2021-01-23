    Stopwatch sw = new Stopwatch();
    sw.Start();
    while (true)
    { 
        if (Name == null)
        {
           CheckName = false;
           break;
        }
        else if(sw.Elapsed.TotalMinutes >= 5)
        {
           // do something
           // break;
        }
    }
    sw.Stop();

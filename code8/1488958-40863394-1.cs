    for (int i = 0; i < numberThreads; i++)
    {
        if (i == 3)
        {
             // Never gets hit
             System.Diagnostics.Debugger.Break();
        }
        Task.Run(() => DoWork(i)); <= action will executed after we exited from for loop
    }

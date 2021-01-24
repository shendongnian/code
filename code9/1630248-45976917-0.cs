    private static async Task readUntilEnd(StreamReader stream, System.Timers.Timer timer, CancellationToken canelToken)
    {
        char[] buffer = new char[1];
        Task readTask = stream.ReadAsync(buffer, 0, 1);
        int cooldown = 5;
        while (!canelToken.IsCancellationRequested)
        {
            if (readTask.IsCompleted)
            {
                 readAChar(buffer[0]);
                        
                 buffer[0] = '\0';
                 readTask = stream.ReadAsync(buffer, 0, 1);
                 timer.Stop();
                 timer.Start();
                 cooldown = 0;
            }
            else
            {
                if (cooldown < 100)
                    cooldown++;
            }
            if (cooldown > 0)
                await Task.Delay(cooldown, canelToken);
        }
                
    }

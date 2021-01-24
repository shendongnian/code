     Console.WriteLine($"Started at: {DateTime.Now}");
     Timer timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds) 
     {AutoReset = true};
     timer.Elapsed += (sender, args) =>
            {
                //Your code here.
            };
     timer.Start();
     Thread.Sleep(TimeSpan.FromMinutes(1));
            
     timer.Stop();

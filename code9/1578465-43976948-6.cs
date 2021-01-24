    // Start the operation 2 seconds after start-up.
    Timer timer = new Timer(TimeSpan.FromSeconds(2).TotalMilliseconds);
    
    timer.Elapsed += (_, __) =>
    {
        try
        {
            // Wrap operation in the appropriate scope (if required)
            using (ThreadScopedLifestyle.BeginScope(container))
            {
                var repo = container.GetInstance<IOrderRepository>();
            
                // This will trigger a cache reload in case the cache has timed out.
                repo.GetAllValid();
            }        
        }
        catch (Exception ex)
        {
            // TODO: Log exception
        }
        
        // Will run again at 01:00 AM tomorrow to refresh the cache
        timer.Interval = DateTime.Today.AddHours(25);
    };
    
    timer.Start();

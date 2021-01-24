    [AsyncTimeout(5000)]
    public async Task<ActionResult> Index(CancellationToken cancellationToken)
    {
        Stopwatch cancellationTimer = Stopwatch.StartNew();
        try
        {                
            await Task.Delay(15000, cancellationToken);
            cancellationTimer.Stop();
            return View();
        }
        catch (Exception e)
        {
             cancellationTimer.Stop();
             Debug.WriteLine($"Elapsed Time {cancellationTimer.ElapsedMilliseconds}");
             throw (e);
        }            
    }

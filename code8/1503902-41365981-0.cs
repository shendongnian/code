    if (Request.Headers.Contains("Origin"))
    {
        var values = Request.Headers.GetValues("Origin");
        // Do stuff with the values... probably .FirstOrDefault()
    }

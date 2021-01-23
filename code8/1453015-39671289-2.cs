    public JsonResult Read(....)
    {
        var all = _userManager.GetStuff();
        var watch = Stopwatch.StartNew();
        var json = JsonConvert.SerializeObject(all);
        Trace.WriteLine("READ" + watch.ElapsedMilliseconds);
        watch.Stop();
        return Content(json, "application/json");  //Takes 40 milliseconds to get here
    }

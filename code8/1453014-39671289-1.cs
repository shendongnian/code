    public JsonResult Read(....)
    {
        var all = _userManager.GetStuff();
        var watch = Stopwatch.StartNew();
        var scriptSerializer = new JavaScriptSerializer();
        var json = scriptSerializer.Serialize(all);
        Trace.WriteLine("READ" + watch.ElapsedMilliseconds);
        watch.Stop();
        return json;  //Takes 40 milliseconds to get here
    }

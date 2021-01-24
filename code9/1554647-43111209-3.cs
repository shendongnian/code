    [HttpPost]
    public ActionResult Demo(String date)
    {
        // other stuff
        ...
        var test = new Test();
        test.Date = DateTime.ParseExact(date, "M/d/yyyy", CultureInfo.InvariantCulture);
        ...
        // other stuff
    }

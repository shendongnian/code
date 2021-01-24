    [Route("allsummaries/yesterday/{day}/{month}/{year}")]
    public ActionResult AllSummaries(int? page, int day, int month, int year)
    {
        var yesterday = new Date(day, month, year);
    }
    
    [Route("allsummaries/yesterday")]
    public ActionResult AllSumaries(int? page)
    {
    }

    [HttpPost]
    public ActionResult Index(string commaSeperatedNumbers)
    {
        var strArray = commaSeperatedNumbers.Split(',');
        // Do your sorting here and update the commaSeperatedNumbers variable.
        ViewData["data"] = commaSeperatedNumbers;
        return View();
    }

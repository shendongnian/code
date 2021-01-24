    public ActionResult Index()
    {
        var model = new SampleViewModel
        {
            Items = new Dictionary<string, string> {{"Referrer", "1"}, {"JobSeeker", "2"}}
        };
        return View(model);
    }

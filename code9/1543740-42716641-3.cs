    public ActionResult Index(IndexParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            foreach(var error in ModelState.Where(ms => ms.Value.Errors.Any()).SelectMany(ms => ms.Value.Errors))
                Debug.WriteLine(error.ErrorMessage);
        }
    
        return View();
    }

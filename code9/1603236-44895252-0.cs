    [HttpPost]
    public ActionResult Create(PersonModels person)
    {
        try
        {
            // TODO: Add insert logic here
            //Adding to database and holding the response in the viewbag.
            string strInsertion = ConnectionModels.insertPerson(person);
            TempData[InsertionResult] = strInsertion;
            return RedirectToAction("Index");
        }
        catch
        {
            return View("Index");
        }
    }
    [HttpGet]
    public ActionResult Index()
    {
        string strInsertion = TempData[InsertionResult];
        return View("Index", new { InsertionResult = strInsertion });
    }
    <label>
        @Model.InsertionResult
    </label>

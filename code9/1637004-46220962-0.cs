    public ActionResult Create(){}
    [HttpPost]
    public ActionResult Create(PersonModel model)
    {
        people.Add(new PersonModel {Age = model.Age, Name = model.Name, Title =model.Title});
        return View();
    }

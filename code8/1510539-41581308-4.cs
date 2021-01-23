    [HttpPost]
    public ActionResult Insert(Person person)
    {
        person.City = person.CitySelectList.SelectedValues;
        // Some code goes here
        return View();
    }

    [HttpGet]
    public ActionResult PersonIndex()
    {
        List<List<Person>> personLists = new List<List<Person>>();
        var personsCodeA = context.Persons.Where(p => p.Code == "A").ToList();
        var personsCodeB = context.Persons.Where(p => p.Code == "B").ToList();
        var personsCodeX = context.Persons.Where(p => p.Code == "X").ToList();
        personLists.Add(personsCodeA);
        personLists.Add(personsCodeB);
        personLists.Add(personsCodeC);
        return View(personLists);
    }

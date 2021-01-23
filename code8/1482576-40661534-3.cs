    public List<string> MyList
    {
        get
        {
            return (List<string>)(
                // Return list if it already exists in the session
                Session[nameof(MyList)] ??
                // Or create it with the default values
                (Session[nameof(MyList)] = new List<string> { "element1", "element2", "element3" }));
        }
        set
        {
            Session[nameof(MyList)] = value;
        }
    }
    public ActionResult Create()
    {
        return View(MyList);
    }
    [HttpPost]
    public ActionResult Create(string txt)
    {
        MyList.Add(txt);
        return View(MyList);
    }

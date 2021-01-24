    [HttpPost]
    public ActionResult NewItemHandler(string name, string weight)
    {
        int id = GenerateNewItem(name, weight);
        Session["ItemID"] = id;
        return View();
    }

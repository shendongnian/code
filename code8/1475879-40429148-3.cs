    public ActionResult Check(string name)
    {
         string[] names = {"name1", "name2", "name3"};//set of possible values
         //validate the string is one of a set of possible values
         if (names.Contains(name.ToLowerInvariant())) return Json(false);
         //...
         return Json(true);
    }

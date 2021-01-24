        public ActionResult Result(string Person)
    {
        Hierarchy h = db.Hierarchies.First(i => i.People == Person);
        if (h == null)
        {
            return HttpNotFound();
        }
        int lvl = h.Level;
        var list = new string[lvl];
        list = h.Hierarchy1.Split('/');
        IQueryable<Hierarchy> TQuery = from a in db.Hierarchies
                                       where list.Contains(a.People)
                                       select a;
        return View("Result", TQuery.ToList());
    }

    public ActionResult Details(int id)
    {
        using (var db = new example_db())
        {
            var model = new BothTables()
            {
                Id = id,
                TableOne = db.table1.Where(x => x.id.Equals(id)).ToList(),
                TableTwo = db.table2.Where(x => x.id.Equals(id)).ToList(),
                Table2 = new Table2ViewModel(),
            };
            return View(model);
        }
    }

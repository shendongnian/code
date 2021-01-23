    public ActionResult Reports(string JIssue, string Status) 
    {
        var Issues  = db.Data
            .Where(d => d.Column.Contains(JIssue) &&
                        d.Column2.Contains(1) &&
                        /* potential other conditions for other columns*/ )
            .Select(i => /* your mapping here */)
            .ToList();
            
        ViewBag.Issues = Issues;
        return View();
    }

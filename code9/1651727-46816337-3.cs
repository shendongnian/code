    public ActionResult Insert(students st)
    {
        _context.stdnts.Add(st);
        _context.SaveChanges();
        return RedirectToAction("Index","Students");
    }

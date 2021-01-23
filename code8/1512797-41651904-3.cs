    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Details(BothTables viewModel)
    {
        if (ModelState.IsValid)
        {
            var entity = new table2();
            var entity.column1 = viewModel.Table2.Column1;
            db.table2.Add(entity);
            db.SaveChanges();
        }
        // Redirect back to the original GET /Content/Details/1 action
        return RedirectToAction("Details", new { id = viewModel.Id });
    }

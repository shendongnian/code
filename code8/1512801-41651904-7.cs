    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Details(BothTables viewModel)
    {
        if (!ModelState.IsValid)
        {
            // some required fields were not populated => we need to
            // redisplay the view so that the user can fix the errors
            // Don't forget to populate the 2 fields:
            using (var db = new example_db())
            {
                viewModel.TableOne = db.table1.Where(x => x.id == viewModel.Id).ToList(),
                viewModel.TableTwo = db.table2.Where(x => x.id == viewModel.Id).ToList(),
            }
            return View(viewModel);
        }
        // At this stage we know that the model is valid
        // and we can save it to the database
        var entity = new table2();
        var entity.column1 = viewModel.Table2.Column1;
        db.table2.Add(entity);
        db.SaveChanges();
        // Redirect back to the original GET /Content/Details/1 action
        // (Redirect-After-Post pattern)
        return RedirectToAction("Details", new { id = viewModel.Id });
    }

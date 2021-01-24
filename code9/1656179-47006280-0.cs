    try
    {
        if (ModelState.IsValid)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    catch (Exception /* ex */)
    {
        //Log the error (uncomment ex and place a break point on the line below to check the inner exception.  Ideally log the error so it can be reviewed.)
        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
    }

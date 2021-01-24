    try
    {
        var loan = db.Members ...
    }
    catch (DbNullException)
    {
        ModelState.AddModelError("searchString", "Danger Will Robinson!");
    }

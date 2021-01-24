    if (ModelState.IsValid)
    {
      //insert data in tables
          RedirectToAction("Register");
    }
    else
    {
    return View();
    }

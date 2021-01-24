        if (!ModelState.IsValid)
        {
            //how do return my model errors back to my View Component?
             ViewBag.Error = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
             return View();
        }
        else
        {
            //do send logic here
            return Content("Success");
        }
    }

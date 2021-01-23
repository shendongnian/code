    [HttpPost]
    public ActionResult About(AboutModel model, string save)
    {
        // your button id/name is save - this value will be initialized only if that button is clicked
        if (!String.IsNullOrEmpty(save))
        {
            // just save
        }
        else
        {
            // save and post... you can check for ModelState.IsValid like:
            if (ModelState.IsValid)
            {
            }
            else
            {
                // invalid model
            }
        }
        return View();
    }

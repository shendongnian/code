    public async IActionResult EventDetails(int eID)
    {
        Event model = new Models.Event();
        var event = context.Events.Include(evt => evt.Artist)
                                  .FirstOrDefault(evt => evt.EventID = eID);
        if (event == null) 
        {
           // return error
        }
        else
        {
           ViewBag.isYours = false;
           var user = await userManager.GetUserAsync(HttpContext.User);
           if (user == null)
           {
              // return error
           }
           if (event.Artist.SomeProperty == user.SomeProperty)
           {
               ViewBag.isYours = true;
               // Populate `model` properties with data from `event`
           }
        }
        return View(model);
    }

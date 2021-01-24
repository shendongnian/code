    [HttpPost]
    [ActionName("action")]
    public ActionResult action(MyClassObject obj)
    {
       if(!ModelState.IsValid)
       {
          return action(); // this is your original action before you do the post
       }
       else
       {
          // do your processing and return view or redirect
          return View(); // or redirect to a success page
       }
    }

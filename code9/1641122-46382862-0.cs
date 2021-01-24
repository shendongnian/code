    [HttpPost]
    public ActionResult NewsLetters(Vmclass.RegisterFeeds fd)
    {
       var list = new List<string>();
       if (!ModelState.IsValid)
       {
          var errors = ViewData.ModelState.Values
                             .SelectMany(f => f.Errors
                                              .Select(x => new {Error = x.ErrorMessage,
                                                      Exception =x.Exception})).ToList();
          return Json(new {Status="error",Errors = errors});
       }
      // to do : Your existing code to save
      return Json(new {Status="success"});
    }

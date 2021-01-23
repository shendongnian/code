    Public ActionResult AssumeThisAsYourPostMethod(YourModel modelObject)
    {
      if(modelObject.Reason=="Other" && String.IsNullOrEmpty(modelObject.Comment) )
      {
        ModelState.AddModelError("Comment","Your Validation Message");
        return View("YourViewName");
      }
    }

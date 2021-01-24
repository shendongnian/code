      [HttpPost]
      public ActionResult GoNext()
      {
      WelcomeModel CheckState = new WelcomeModel();
      TryUpdateModel(CheckState );
      if (CheckState.chk0 && CheckState.chk1 && CheckState.chk2 != false)
      {
      return RedirectToAction("Index", "Tab1");
      }
      
      else
      {
      ModelState.AddModelError(String.Empty, "Message");
    
      return Index();
    
      }

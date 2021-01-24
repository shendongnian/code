    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateUserRequest([Bind(Include = "UserRequest")] RequestUserModel model)
    {
         // and here all properties has inputed values... YEAH!!!  :)
        
         var firstName = model.UserRequest.FirstName;
         
         return RedirectToAction("Index");
    }

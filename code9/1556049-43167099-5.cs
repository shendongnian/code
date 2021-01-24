    [HttpPost]
    public ActionResult ModifyPassword(ModifyPasswordViewModel model)
    {
         if ( this.ModelState.IsValid )
         {
            ...
         }
    }

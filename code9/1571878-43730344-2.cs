    public ActionResult Action(...)
    {
         var model = ...
    
         ...
    
         if (Request.IsAjaxRequest())
         {
              return PartialView( "Partial", model.PartialModel );
         }
         else
         {
              return View( model );
         }
    }

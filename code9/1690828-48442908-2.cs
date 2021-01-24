     private YourModel _yourModel;
     public ActionResult MyAction(YourModel model)
     {
          _yourModel = model;
           return View();
     }
    
     protected override void OnResultExecuted(ResultExecutedContext filterContext)
     {
           //Access _yourModel here     
     }

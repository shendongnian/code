     public ActionResult GetHeader()
     {
         var vm = new BaseViewModel { BodyClass= "test-class" };
         return PartialView("~/Views/Shared/_HeaderLayout.cshtml", vm);
     }
 

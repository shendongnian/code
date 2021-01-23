     public class CoolController : BaseControllers.CoolController
     {
         public override ViewResult Get() 
         {
             var ignoredResult = base.Get();
             // ViewData.Model now refers to awesomeModel
             return View("NotGet");
         }
     }

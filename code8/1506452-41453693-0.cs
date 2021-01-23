     namespace BaseControllers
     {
         public class CoolController
         {
             public virtual ViewResult Get() 
             {
                 var awesomeModel = new object();
                 return View(awesomeModel);
             }
         }
     }

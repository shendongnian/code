    public class HomeController : Controller
    {
     [HttpPost]
      public ActionResult ExplicitServer(UserViewModel model)
         {
       //Write custom logic to validate UserViewModel
       if (string.IsNullOrEmpty(model.UserName))
       {
         ModelState.AddModelError("UserName", "Please enter your
      name");
     }
      if (!string.IsNullOrEmpty(model.UserName))
      {
        Regex emailRegex = new Regex(".+@.+\\..+");
         if (!emailRegex.IsMatch(model.UserName))
          
           ModelState.AddModelError("UserName", "Please enter correct
            email address");
       }
       if (ModelState.IsValid) //Check model state
      {
          //TO DO:
       }
      }
      }

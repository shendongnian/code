    public class MyController : Controller {
        // [Authorize(Roles="Admin")]  could do it this way
        public ActionResult AdminOnly() {
            // or..
             if(!Common.UsuarioLogueado.Admin)
             {
                 return new HttpStatusCodeResult(401);
                 // or
                 // return View("Error") // usually there is an 'Error' view the Shared folder
             }
             return View();
        }
    }

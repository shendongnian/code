    public class ClientesAdmin : Controller {
        // [Authorize(Roles="Admin")]  could do it this way
        public ActionResult List() {
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

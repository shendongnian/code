    public class AccountsController : Controller
     {
         // GET: App/Accounts
         [Route("app/accounts/list/{Id}")]
         public ActionResult List(int Id)
         {
    
              return View();
          }
      }

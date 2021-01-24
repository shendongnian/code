    namespace Resolve.Controllers
    {
    
        public class EquationController : Controller
        {
         // GET: Equation
            public ActionResult Promise()
            {
                return View();
            }
            
            //[AcceptVerbs(HttpVerbs.Post)] //don't use this
            [HttpPost] //use this instead
            public ActionResult Promise(Solve equation)
            {
                equation.Calculate(); //calls this
                return View(equation);
            }
         }         
    
     }

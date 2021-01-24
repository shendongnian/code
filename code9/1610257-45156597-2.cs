    public void Calculate () //removes the out double for x1 and x2
    {
        double inside = (b * b) - 4 * a * c;
        if (inside < 0)
        {
            x1 = double.NaN;
            x2 = double.NaN;
        }
        else
        {
            double eqn = Math.Sqrt(inside);
            x1 = (-b + eqn) / (2 * a);
            x2 = (-b - eqn) / (2 * a);
        }
    }
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

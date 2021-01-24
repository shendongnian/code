       public class LookupController : Controller
        {
            //
            // GET: /Lookup/
    
            public ActionResult MyLookup(string Company, string Recruiter)
            {
                // this is how to pass the value of parameter company and recruiter input from index.
                //Your Action here and you can use to Debug while runnning notice that the company and the recruiter has a content from index home input
                return View();
            }
    
        }

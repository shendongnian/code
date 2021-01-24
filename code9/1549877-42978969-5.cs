    public class MyController : Controller
    {
        private MyDBContext db = new MyDBContext();
        //...
    
        [HttpPost]
        [ValidateInput(false)]
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index(ViewModel rb)
        {
            var query = this.buildQuery().ToString();
    
            // The results returned by the query contain all members of B except for ID
            IEnumerable<A> goals = db.Database.SqlQuery<A>(query);
    
            IList<B> goalsToInsert = new List<B>();
            // Create a new List of Objects of type B. 
            // Constructor allows for all members of A to be assigned to B 
            goals.ToList().ForEach(x => {goalsToInsert.Add(new B(x));});
            db.B.AddRange(goalsToInsert);
            db.SaveChanges();
            rb.goalList = goalsToInsert;
            return View(rb);
        }
    }

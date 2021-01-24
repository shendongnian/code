    public class TestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); // This is your database connection referenced in the web.config	
        public ActionResult test() 
        {
		    string sql = @"SELECT COUNT(*) FROM..."; // finish your query here
		    int count = db.Database.SqlQuery<int>(sql).Single();
		    return View(count); // pass your count to the view
	    }
    }

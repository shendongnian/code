    public class EmailCampaignController : Controller
    {
        private db_likEntities db = new db_likEntities ();
        // GET: Only Subscribed Users info
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Countries)
                                .Where(u => u.status == 1);
            return View(users.ToList());
        }
     }

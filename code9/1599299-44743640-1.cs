    public class EmailCampaignController : Controller
    {
        private db_likEntities db = new db_likEntities ();
        // GET: Only Subscribed Users info
        public ActionResult Index()
        {
            //first get all subscriptions whose status is 1
        var trueSubscriptions = db.Subscriptions.Where(s => s.status == 1).ToList();
        //use this variable to filter users by Id
        List<User> users = new List<User>();
        var allUsers = db.Users.Include(u => u.Countries);
        for (int i = 0; i < trueSubscriptions; i++)
        {
            users.Add(allUsers.FirstOrDefault(x => x.Id == trueSubscriptions[i].UserId));
        }
        
        return View(users.ToList());
        }
     }

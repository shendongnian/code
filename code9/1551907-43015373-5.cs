	public class HomeController : Controller{
		private readonly ApplicationDbContext _identityContext;
		private readonly BaseDbContext _baseContext;
		
		public HomeController(ApplicationDbContext identityContext, BaseDbContext baseContext)
		{
			_identityContext = identityContext;
			_baseContext = baseContext;
		}
		
		public IActionResult Index()
		{
			// get currently logged in user's username from ASP.NET Identity
			string userName = User.Identity.Name;
			
			// get username in Member table of baseDb where Id column is 123
			string anotherUserName = _context.Member().FirstOrDefault(m => m.Id == 123).UserName;
			
			// add new row in basedb.Member table with identity username as foreign key
			var model = new Member
			{
				UserName = userName,
				Age = 1,
				Favorites = new List<Favorite>();
			};
			_baseContext.Add(model);
			_baseContext.SaveChanges();
			
			return View();
		}
	}

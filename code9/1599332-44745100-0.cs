	public ActionResult Index()
	{
		var users = db.Users
			.Where(d => d.Subscriptions.Any(x => x.Status == true))
			.Select(u => u.Email);
			
		return View(users);
	}

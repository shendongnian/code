	public ActionResult Index()
	{
		var users = db.Users
			.Where(d => d.Subscriptions.Any(x => x.Status == true))
			.Select(u => new UserWithEmail() { UserId = u.UserId, Email = u.Email };
			
		return View(users);
	}

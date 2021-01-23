    public ActionResult JoinTeam(int id)
    {
    	using(ApplicationDbContext db = new ApplicationDbContext())
    	{
    		var currentUserId = User.Identity.GetUserId();
    		var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
    		var currentUser = manager.FindById(User.Identity.GetUserId());
    
    		currentUser.EkipaId = id;
    		db.Users.Attach(currentUser);
    		db.Entry(currentUser).State = System.Data.Entity.EntityState.Modified;
    		db.SaveChanges();
    		return RedirectToAction("Ekipa", "Home");
    	}
    }

	ApplicationDbContext db = new ApplicationDbContext();
	IQueryable query = db.Users
		.Include(i => i.Claims)
		.Include(i => i.Roles)
		.Where(w => w.Email != null);
	string generatedSql = query.ToString();

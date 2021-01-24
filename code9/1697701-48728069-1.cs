	from u in stuff.Users
	group u by 0 into grp
	select new
	{
		IsDuplicateEmail = grp.Any(x => x.Email == user.Email),
		IsDuplicateUserName = grp.Any(x => x.UserName == user.UserName)
	}

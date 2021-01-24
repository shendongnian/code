	foreach (var user in _userManager.Users.Include(u => u.Roles).ToList())
	{              
		list.Add(new ApplicationUserListViewModel {
			UserEmail = user.Email,
			Roles = user.Roles
		});
	}

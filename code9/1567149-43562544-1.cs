	var users = _userManager.Users.Include(u => u.Roles)
							.Select(u => new ApplicationUserListViewModel {
								UserEmail = user.Email,
								Roles = user.Roles
							})
							.ToList();

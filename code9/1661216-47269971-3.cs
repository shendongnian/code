    [Authorize(Roles = "Admin")]
	public ActionResult RoleManager()
	{
		ViewBag.Message = "Role Management Page";
		var databaseContext = new ApplicationDbContext();                   // Get the Database Context
		var users = databaseContext.Users.Include(u => u.Roles).ToList();   // Get all users from the Database and their Roles
		// Create the UpdateUserRolesViewModel
		var updateUserRolesViewModel = new UpdateUserRolesViewModel
		{
			Id = 0, // Not sure what else the Id would be
			UserViewModels = new List<UserViewModel>()
		};
		// Add each user to the UserViewModels list
		for (int i = 0; i < users.Count(); i++)
		{
			var userViewModel = new UserViewModel
			{
				Id = users.AsEnumerable().ElementAt(i).Id,
				Email = users.AsEnumerable().ElementAt(i).UserName,
				RoleViewModels = new List<RoleViewModel>(),
				DeleteUser = false
			};
			// Add each role from the Roles table to the RoleViewModels list, check if user has that role
			foreach (var role in databaseContext.Roles)
			{
				var roleViewModel = new RoleViewModel
				{
					Id = role.Id,
					Name = role.Name,
					IsSelected = users.AsEnumerable().ElementAt(i).Roles.Any(identityUserRole => identityUserRole.RoleId.Contains(role.Id))
				};
				userViewModel.RoleViewModels.Add(roleViewModel);
			}
			updateUserRolesViewModel.UserViewModels.Add(userViewModel);
		}
		return View(updateUserRolesViewModel);
	}
	[HttpPost]
	[Authorize(Roles = "Admin")]
	[ValidateAntiForgeryToken]
	public async Task<ActionResult> UpdateUsersRolesAsync(UpdateUserRolesViewModel updateUserRolesViewModel)
	{
		try
		{
			// Attempt to update the user roles
			foreach (var user in updateUserRolesViewModel.UserViewModels)
			{
				// Delete user
				//TODO: Prompt user to confirm deletion if one or more people are being deleted
				if (user.DeleteUser)
				{
					var userToDelete = await UserManager.FindByIdAsync(user.Id);    // Get the ApplicationUser object of who we want to delete
					await UserManager.DeleteAsync(userToDelete);                    // Delete the user
					continue;                                                       // Don't try to update the roles of a deleted user.
				}
				// Remove all roles from the User
				var rolesToRemove = await UserManager.GetRolesAsync(user.Id);
				await UserManager.RemoveFromRolesAsync(user.Id, rolesToRemove.ToArray());
				// Add roles to the User
				foreach (var roleViewModel in user.RoleViewModels.Where(r => r.IsSelected))
				{
					await UserManager.AddToRoleAsync(user.Id, roleViewModel.Name);
				}
			}
			return RedirectToAction("RoleManager");
		}
		catch
		{
			//TODO: Properly catch errors
			return RedirectToAction("RoleManager");
		}
	}

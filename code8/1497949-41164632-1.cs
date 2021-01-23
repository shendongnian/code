		bool AddUserAndRole(ApplicationDbContext context, ApplicationUserManager um, Users user, string roleName)
		{
			return AddUserToRole(context, um, user, "cadEdit");
		}
		bool AddUserToRole(ApplicationDbContext context, ApplicationUserManager um, Users user, string roleName)
		{
			IdentityResult ir;
			var rm = new RoleManager<IdentityRole>
				(new RoleStore<IdentityRole>(context));
			if(!rm.RoleExists(roleName))
			{
				var createResult = rm.Create(new IdentityRole(roleName));
				if(!createResult.Succeeded)
				{
					return false;
				}
			}
			return um.AddToRole(user.Id, roleName).Succeeded;
		}

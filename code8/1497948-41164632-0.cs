		bool AddUserAndRole(ApplicationDbContext context, ApplicationUserManager um, Users user)
		{
			IdentityResult ir;
			var rm = new RoleManager<IdentityRole>
				(new RoleStore<IdentityRole>(context));
			if(!rm.RoleExists("canEdit"))
			{
				var createResult = rm.Create(new IdentityRole("canEdit"));
				if(!createResult.Succeeded)
				{
					return false;
				}
			}
			return um.AddToRole(user.Id, "canEdit").Succeeded;
		}

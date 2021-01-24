    var initialQuery = from users in _context.Users
				where users.Id == id
				join userRoles in _context.UserRoles on users.Id equals userRoles.UserId
				join roles in _context.Roles on userRoles.RoleId equals roles.Id
				select new
				{
					UserID = users.Id,
					UserName = users.UserName,
					RoleID = roles.Id,
					RoleName = roles.Name
				};
    IEnumerable<User> result = initialQuery
    				.GroupBy(x => new { x.UserID, x.UserName })
    				.Select(x => new User
    				{
    					Id = x.Key.UserID,
    					UserName = x.Key.UserName,
    					Roles = x.Select(a => new Role { Id = a.RoleID, Name = a.RoleName }).ToList() as ICollection<Role>
    				});

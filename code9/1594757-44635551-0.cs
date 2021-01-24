    public IdentUser FindById(int userId)
		{
			return _dbContext.Users.Include(user => user.IdentUserProfile)
				.Include(role => role.IdentUserProfile.IdentUserOrgRole)
				.Include(client => client.IdentUserProfile.IdentMapApplicationsWithUser).FirstOrDefault(x => x.Id == userId);
		}

    public bool AssignUserToProject(string userId, Project project)
	{
		if (!IsUserAssignedToProject(userId, project))
		{
			project.Users.Add(db.Users.FirstOrDefault(u => u.Id == userId));
			db.SaveChanges();
			return false;
		}
		return true;            
	}

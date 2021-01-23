	public List<ApplicationUser> GetUsersConnectedToChat()
	{
		List<ApplicationUser> users = Users
			.Where(IsActiveInChat)
			.ToList();
		return users;
	}

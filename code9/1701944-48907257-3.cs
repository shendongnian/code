	public static async Task<List<UserProf>> ProfileSetUp(string userName, string firstName, string lastName, string profession, string county, string description)
	{
		CurrentPlatform.Init();
		return await Client.GetTable<UserProf>()
			.Where(x => x.Username == userName
					&& x.Firstname == firstName
					&& x.Lastname == lastName
					&& x.Profession == profession
					&& x.County == county
					&& x.Description == description)
			.ToListAsync();
	}
	

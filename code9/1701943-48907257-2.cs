	public static Task<UserProf> ProfileSetUp(string userName)
	{
		CurrentPlatform.Init();
		return Client.GetTable<UserProf>().SingleOrDefaultAsync(x => x.Username == userName);
	}

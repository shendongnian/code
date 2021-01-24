	private string GetInvolvementLogging(ICollection<UserInvolvement> newInvolvement, ICollection<UserInvolvement> oldInvolvement)
	{
		//I defined the new and old dictionary's for you to know what useful data is inside UserInvolvement. 
		//Both are Dictionary<int, int>, because The Involvement is just a enum flag. Integer. UserId is also Integer.
		var newDict = newInvolvement.ToDictionary(x => x.UserID, x => x.Involvement);
		var oldDict = oldInvolvement.ToDictionary(x => x.UserID, x => x.Involvement);
	
		//I Want to compare new to old -> and get 2 dictionaries: added and removed.
		var usersAdded = new Dictionary<int, Involvement>();
		var usersRemoved = new Dictionary<int, Involvement>();
	
		//What is the best algoritm to accomplish this?
		foreach (var newItem in newDict)	
			if (!oldDict.ContainsKey(newItem.Key)) usersAdded.Add(newItem.Key, newItem.Value);
	
		foreach (var oldItem in oldDict)
			if (!newDict.ContainsKey(oldItem.Key)) usersRemoved.Add(oldItem.Key, oldItem.Value);
	
		return GetInvolvementLogging(usersAdded, usersRemoved);
	}

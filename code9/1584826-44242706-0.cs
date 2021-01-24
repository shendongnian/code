	private string GetInvolvementLogging(ICollection<UserInvolvement> newInvolvement, ICollection<UserInvolvement> oldInvolvement)
	{
		//I defined the new and old dictionary's to focus on the relevant data inside UserInvolvement. 
		var newDict = newInvolvement.ToDictionary(x => x.UserID, x => (Involvement)x.Involvement);
		var oldDict = oldInvolvement.ToDictionary(x => x.UserID, x => (Involvement)x.Involvement);
		var intersection = newDict.Keys.Intersect(oldDict.Keys); //These are the id's of the users that were and remain involved. 
		var usersAdded = newDict.Keys.Except(intersection);
		var usersRemoved = oldDict.Keys.Except(intersection);
		var addedInvolvement = newDict.Where(x => usersAdded.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value); 
		var removedInvolvement = oldDict.Where(x => usersRemoved.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value);
		//Check if the already involved users have a changed involvement.
		foreach(var userId in intersection)
		{
			var newInvolvementFlags = newDict[userId];
			var oldInvolvementFlags = oldDict[userId];
			if ((int)newInvolvementFlags != (int)oldInvolvementFlags)
			{
				var xor = newInvolvementFlags ^ oldInvolvementFlags;
				var added = newInvolvementFlags & xor;
				var removed = oldInvolvementFlags & xor;
				if (true)
				{
					addedInvolvement.Add(userId, added);
				}
				if (true)
				{
					removedInvolvement.Add(userId, removed);
				}
			}
		}
		return GetInvolvementLogging(addedInvolvement, removedInvolvement);
	}

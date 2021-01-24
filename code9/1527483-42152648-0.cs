	var filter = string.Format(
		"(&(objectCategory=User)(whenChanged>={0:yyyyMMddHHmmss.0Z}))", //This is the DateTime format it takes.
		DateTime.UtcNow.AddHours(-48) // Always use UTC to make life easy. Otherwise you need to change the above time formatting.
		);
	
	using (var domain = new System.DirectoryServices.DirectoryEntry())
	{
		using (var searcher = new DirectorySearcher(domain, filter))
		{
			foreach (SearchResult result in searcher.FindAll())
			{
				var de = result.GetDirectoryEntry();
				
				// Now you have a DirectoryEntry. Business as usual.
				de.Properties["UserPrincipalName"].Value.Dump();
				de.Properties["WhenChanged"].Value.Dump();
				de.Properties["MemberOf"].Value.Dump();
			}
		}
	}

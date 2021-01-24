	using(var serverManager = ServerManager.OpenRemote("my-remote-server"))
	{
		if (serverManager.Sites.AllowsAdd())
		{
			var site = serverManager.Sites.Add(siteName, path, port);
            // use site for something, like changing its bindings or something else
			serverManager.CommitChanges(); // without this, changes are made only in memory
		}
	}

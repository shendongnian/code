	Session localSession = null;
	try
	{
		localSession = theRealm.All<Session>().First((Session session) => session.UserId == "1");
	}
    catch (InvalidOperationException error) when (error.Message == "Sequence contains no matching element")
	{
		theRealm.Write(() =>
		{
			localSession = new Session() { UserId = "1", Token = "SO" };
		});
	}
	D.WriteLine($"{localSession?.UserId}:{localSession?.Token}");

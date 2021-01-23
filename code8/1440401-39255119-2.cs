	Session session = null;
	var sessions = theRealm.All<Session>().Where((Session localSession) => localSession.UserId == "1");
	if (!sessions.Any())
		theRealm.Write(() =>
		{
			session = new Session() { UserId = "1", Token = "SO" };
		});
	else
		session = sessions.First();
	D.WriteLine($"{session?.UserId}:{session?.Token}");

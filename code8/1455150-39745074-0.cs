	Predicate<object> viewFilter1 = f =>
	{
		ExternalUser u = f as ExternalUser;
		return u.AgentName.ToLower().StartsWith(agentName.ToLower());
	};
	Predicate<object> viewFilter2 = f =>
	{
		ExternalUser u = f as ExternalUser;
		return u.ExternalLogin.ToLower().StartsWith(login.ToLower());
	};
	Predicate<object> viewFilter = f => viewFilter1(f) && viewFilter2(f);

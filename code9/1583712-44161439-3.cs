	var foo = new RequestServiceNumberOfQualifiers()
	{
		numberOfQualifiers = new List<List<nbrOfQualifiers>>()
		{
			new List<nbrOfQualifiers>()
			{
				new nbrOfQualifiers(){ Value = 2, Qualifier = "Person"},
			},
			new List<nbrOfQualifiers>()
			{
				new nbrOfQualifiers(){ Value = 3, Qualifier = "User1"},
				new nbrOfQualifiers(){ Value = 4, Qualifier = "User2"},
			}
		}
	};

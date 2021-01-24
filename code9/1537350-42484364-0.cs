	persons.Select(x =>
	{
		if (PersonIsAdded(x))
		{
			var person = GetPerson(x);
			person.Address = "XXX";
			person.SubscriptionList.Add(
				new subscription() { Name = "newspaperName " });
			return person;
		}
		else
		{
			return new Person()
			{
				Address = "XYZ",
				SubscriptionList = new []
				{
					new subscription() { Name = "newspaperName" }
				}.ToList(),
			}
		}
	}).ToList();

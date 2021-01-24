		if (person == null)
		{
			// otherwise create and add him
			Person p = new Person()
			{
				Name = "John Smith",
				Age = 25
			};
            db.Persons.Add(p);
		}
		// forever
		while (true)
		{
			Person p = db.Persons.Single(item => item.Name == "John Smith");
			Console.WriteLine("Found him by name! Age: " + p.Age);
			Person p2 = db.Persons.Single(item => item.ID == 3);
			Console.WriteLine("Got person ID 3!   Age: " + p2.Age);
			Console.WriteLine("Waiting three seconds...\n");
			Thread.Sleep(1000 * 3);
		}

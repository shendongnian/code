			IEnumerable<Person> canVotePersons = data.Recursive(p => p.Children, p => p.Age >= 18);
			foreach(Person voter in canVotePersons)
			{
				listBox1.Items.Add(voter.Name);
			}
			IEnumerable<Person> allPersons = data.Recursive(p => p.Children);
			foreach (Person person in allPersons)
			{
				listBox2.Items.Add(string.Format("Name: {0} Age: {1}", person.Name, person.Age));
			}

    Expression<Func<Person, int>> personIdSelector = person => person.PersonID;
    var query = Persons
		.Select(p =>
		new {
			a = personIdSelector.Inline(p)
		})
		.ApplyInlines();

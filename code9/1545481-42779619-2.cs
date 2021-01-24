	Junction where = Restrictions.Conjunction();
	where.Add(Restrictions.Eq(Projections.Property<MyEntity>(x => x.Field), findValue));
	where.Add(Restrictions.................);
	where.Add(Restrictions.................);
	entityList = Repository.FindBy<MyEntity>(null, where, 100);

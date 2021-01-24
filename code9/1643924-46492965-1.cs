    DbSet<Person> GetDbSet(int type)
	{
		if (type == 0)
		{
			return (DbSet<Person>)Teachers.Cast<Person>();
		}
		else
		{
			return (DbSet<Person>)Students.Cast<Person>();
		}
	}

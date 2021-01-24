    IQueryable<Person> GetPerson(int type)
	{
		if (type == 0)
		{
			return Teachers.Cast<Person>();
		}
		else
		{
			return Students.Cast<Person>();
		}
	}

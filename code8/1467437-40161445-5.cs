	foreach (var item in Items)
	{
		Student student = new Student
		{
			StudentId = item.Id,
			Age = item.Age,
			Description = item.Description
		};
		_context.Student.Add(student);
		
		try
		{
			_context.SaveChanges();
		}
		catch (MyCustomValidationException ex)
		{
			_context.Student.Remove(student);
		}
	}

	foreach (var item in Items)
	{
		Student student = new Student
		{
			StudentId = item.Id,
			Age = item.Age,
			Description = item.Description
		};
		
		if (student.IsValid())
		{
			_context.Student.Add(student);
		}
	}
	_context.SaveChanges();

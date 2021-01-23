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
		} // else do something with invalid data! maybe warn user or log it ...
	}
	_context.SaveChanges();

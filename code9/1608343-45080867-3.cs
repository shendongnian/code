	List<Marks> marks = new List<Marks>()
	{
			new Marks("Maths", 90),
			new Marks("Science", 80),
			new Marks("Physics", 95)
	};
	
	var students = new Student(marks);
	students.Marks.RemoveAll(x => x.Subject != "Maths");

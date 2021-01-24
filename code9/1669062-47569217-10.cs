	const string MathCourseName = "Math";
		var Student1 = new Student("Alice");
		Student1.Infos.Add(new Info(MathCourseName, 4));
		var Student2 = new Student("Bob");
		Student2.Infos.Add(new Info(MathCourseName, 2));
		
		var Student3 = new Student("Cesar");
		Student3.Infos.Add(new Info("English", 3));
		var repository = new StudentRepository();
		
		repository.Add(Student1);
	    repository.Add(Student2);
		repository.Add(Student3);
		
		foreach(var kvp in repository.GetCoursesByStudentName(MathCourseName)) {
		    Console.WriteLine(kvp.Key + ": " + kvp.Value.Course + " - " + kvp.Value.Grade);	
		}
		
		var bobsMathGrade = repository.GetGrade("Bob", MathCourseName);
		Console.WriteLine("Bobs math grade: " + bobsMathGrade);	
    

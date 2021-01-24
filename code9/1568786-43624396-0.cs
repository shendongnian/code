	class Student
	{
		public string name = "";
		public int grade = 0;
		public Student()
		{
		}
	}
	List<Student> GetStudents(string fileName)
	{
		return (from string line in System.IO.File.ReadAllLines(fileName)
				let data = line.Split(",".ToArray())
				select new Student { name = data[0], grade = int.Parse(data[1]) }).ToList();
	}

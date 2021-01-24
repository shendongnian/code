	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Salary { get; set; }
		public string Position { get; set; }
		public int Intern { get; set; }
	
		public Student(string name, string position, int intern, decimal salary)
		{
			this.Name = name;
			this.Position = position;
			this.Intern = intern;
			this.Salary = salary;
		}
	}

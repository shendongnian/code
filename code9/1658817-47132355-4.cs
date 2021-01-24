	public class Student
	{
		private int _next_id = 0;
		public int Id { get; private set; }
		public string Name { get; set; }
		public decimal Salary { get; set; }
		public string Position { get; set; }
		public int Intern { get; set; }
	
		public Student(string name, string position, int intern, decimal salary)
		{
			this.Id = _next_id++;
			this.Name = name;
			this.Position = position;
			this.Intern = intern;
			this.Salary = salary;
		}
	}

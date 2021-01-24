	public class Program
	{
		[PrimaryKey, AutoIncrement]
		public int ProgramId { get; set; }
		public string Name { get; set; }
		
		[OneToMany(CascadeOperations = CascadeOperation.CascadeDelete)]
		public Training[] Trainings {get; set; }
		
		[OneToMany(CascadeOperations = CascadeOperation.CascadeDelete)]
		public Instructor[] Instructors {get; set; }
	}

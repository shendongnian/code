	public class Student
	{
		public string Name { get; set; }
		public ICollection<Course> Courses { get; set; }
	}
	public class Course
	{
		public string Name { get; set; }
		public ICollection<Student> Student { get; set; }
		public ICollection<Exam> Exams { get; set; }
	}
	public class Exam
	{
		public Course Course { get; set; }
		public Student Student { get; set; }
		public decimal Grade { get; set; }
	}

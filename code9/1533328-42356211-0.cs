	class Student : IComparable<Student>
	{
		public int score = 0;
		public string name = "";
		public int CompareTo(Student other)
		{
			if (score == other.score)
			{
				return name.CompareTo(other.name);
			}
			else
			{
				return other.score.CompareTo(score);
			}
		}
	}
	static void Main()
	{
		SortedSet<Student> students = new SortedSet<Student>();
		students.Add(new Student { score = 20, name = "abcd" });
		students.Add(new Student { score = 10, name = "bcde" });
		students.Add(new Student { score = 10, name = "acde" });
		students.Add(new Student { score = 30, name = "cdef" });
		students.Add(new Student { score = 10, name = "abce" });
	}

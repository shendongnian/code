    static void Main(string[] args)
	{
		var lines = System.IO.File.ReadAllLines(@"C:\Users\thingstadbc\OneDrive - Pella Corporation\My Documents\scores.csv")
			.ToList();
		var scores = lines.Skip(1)
            .Select(l =>
		    {
			    var split = l.Split(',');
			    return new { student = split[1].Trim(),
				    score = Int32.Parse(split[3].Trim()) };
		    });
		var orderedStudents = scores.GroupBy(s => s.student)
			.OrderByDescending(g => g.Average(s => s.score));
		var topStudent = orderedStudents.First();
		Console.WriteLine("{0} has the top scores with {1}", 
            topStudent.Key, topStudent.Average(s => s.score));
		Console.ReadKey(true);
	}

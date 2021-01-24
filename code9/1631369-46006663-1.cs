    void Main()
    {
        foreach (var courses in GetCourses().GetPermutations())
        {
            Console.WriteLine(string.Join(" -> ", courses
                .Select(x => x.ToString())
                .Concat(new [] { "DONE" })));
        }
    }
    
    // Define other methods and classes here
    public class Course
    {
        public string Name { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0} ({1:hhmm}-{2:hhmm})",
               Name, Start, End);
        }
    }
    
    IEnumerable<Course> GetCourses() 
    {
        var data = @"
    | FINANCE 101       |   9:00 AM     |   10:00 AM    |
    | FINANCE 102       |   10:00 AM    |   11:00 AM    |
    | PYTHON 300        |   10:00 AM    |   11:00 AM    |
    | SECURITY 101      |   11:00 AM    |   12:00 PM    |
    | ECONOMICS 101     |   9:00 AM     |   12:00 PM    |
    | DATABASE 200      |   11:00 AM    |   1:00 PM     |
    ".Trim();
    
        return data.Split('\n')
            .Select(r => r.Split('|').Select(c => c.Trim()).ToArray())
            .Select(x => new Course
            {
                Name = x[1],
                Start = DateTime.ParseExact(x[2], "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay,
                End = DateTime.ParseExact(x[3], "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay
            });
    }
    
    public static class CourseExtensions
    {    
        public static IEnumerable<IEnumerable<Course>> GetPermutations(this IEnumerable<Course> courses)
        {
            return GetCoursesHelper(courses, TimeSpan.FromHours(9));
        }
        private static IEnumerable<IEnumerable<Course>> GetCoursesHelper(IEnumerable<Course> courses, TimeSpan from)
        {        
            foreach (var course in courses)
            {
                if (course.Start < from) continue;
                
                yield return new[] { course };
                
                var permutations = GetCoursesHelper(courses, course.End);
                foreach (var subPermutation in permutations)
                {
                    yield return new[]{ course }.Concat(subPermutation);
                }
            }
        }
    }

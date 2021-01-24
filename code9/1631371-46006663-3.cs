    public static class CourseExtensions
    {    
        public static IEnumerable<IEnumerable<Course>> GetPermutations(this IEnumerable<Course> courses)
        {
            return GetCoursesHelper(courses, TimeSpan.Zero);
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

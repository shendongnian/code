    var topStudents = allStudents
                    .GroupBy(s => s.Gender.ToUpper()) // Dividing the students to groups by gender
                    .Where(g => g.Key == "M" || g.Key == "F") // Including only the Male and Female genders
                    .Select(g => new KeyValuePair<int, IEnumerable<Student>>(g.Max(s => s.Marks), g)) // Storing the group together with it's highest score value
                    .Select(g => g.Value.Where(s => s.Marks == g.Key)) // From each group, selecting the student that have the highest score
                    .SelectMany(s => s) // selecting all the students from all the inner groups
                    .ToList();

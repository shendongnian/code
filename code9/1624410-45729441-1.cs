    var topStudents = allStudents
                    .GroupBy(s => s.Gender.ToUpper()) // Dividing the students to groups by gender
                    .Where(g => g.Key == "M" || g.Key == "F") // Including only the Male and Female genders
                    .Select(g => g.Where(s => s.Marks == g.Max(i => i.Marks))) // From each group, finding the highest mark and selecting from that groups all the student with that mark
                    .SelectMany(s => s) // selecting all the students from all the inner groups
                    .ToList();

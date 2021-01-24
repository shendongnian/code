            public IEnumerable<Student> GetAllStudents()
            {
                var myquery = databaseEDM.Students
                    .GroupBy(x => new { x.StudentName, x.Class })
                    .Select(s => new
                    {
                        StudentName = s.Key.StudentName,
                        Class = s.Key.Class,
                        GPA = s.Average(g => g.GPA),
                        Courses = string.Join(" ", s.Select(c => c.Course + c.FinalGrade)),
                        CSCIGPA = s.Average(cs => cs.CSCIGPA)
                    })
                    .OrderBy(x => x.Class)
                    .ThenByDescending(x => x.GPA)
                    .ThenByDescending(x => x.CSCIGPA)
                    .ToList()
                    .Distinct();
                return myquery;
            }
     

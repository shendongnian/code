    var result = Student.GetAllStudents()
                        .GroupBy(s => s.Name)
                        .Select(x=> new { StudentName = x.Key, SubjectName = String.Join(",",
                       x.SelectMany(y=>y.Subjects)
                        .ToList()});

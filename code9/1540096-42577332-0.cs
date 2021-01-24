    var result = school
                    .classAttribute
                    .SelectMany(c => c.students)
                    .Where(s => s.StudentName == "some dict key")
                    .Select(s => new CustomObject
                    {
                        StudentID = s.StudentID,
                        StudentName = s.StudentName,
                        Height = s.Height,
                        Weight = s.Weight
                    }).Single();

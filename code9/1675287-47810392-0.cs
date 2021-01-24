            var grouped = results.GroupBy(r => r.StudentID).Select(g => new
            {
                StudentID = g.Key,
                ExamTypes = g.GroupBy(r => r.ExamType).Select(g2 => new
                {
                    ExamType = g2.Key,
                    ExamNames = g2.GroupBy(r => r.ExamName).Select(g3 => new
                    {
                        ExamName = g3.Key,
                        SubjectNames = g3.GroupBy(...)
                    })
                })
            });

            var grouped = results.GroupBy(r => r.StudentID).Select(g => new
            {
                StudentID = g.Key,
                ExamTypes = g.GroupBy(r => r.ExamType).Select(g2 => new
                {
                    ExamType = g2.Key,
                    ExamNames = g2.GroupBy(r => r.ExamName).Select(g3 => new
                    {
                        ExamName = g3.Key,
                        SubjectNames = g3.GroupBy(r => r.SubjectName).Select(g4 => new
                        {
                            SubjectName = g4.Key,
                            SubComponents = g4.Select(r => new { SubjectComponentName = r.SubjectComponentName, ExamDate = r.ExamDate, MaxMark = r.MaxMark, MarkObtained = r.MarkObtained /* others here */ })
                        })
                    })
                })
            });
            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(grouped);

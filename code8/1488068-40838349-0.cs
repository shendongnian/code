    var students = (from s in db.Students.Include("Batches")
                                select new StudentViewModel
                                {
                                    Name = s.Name,
                                    Gender = s.Gender,
                                    Age = s.Age,
                                    BatchId = s.Batches.Id,
                                    BatchName = s.Batches.BatchName
                                }).ToList();
                return students;

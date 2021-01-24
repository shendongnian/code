    public List<StudentDataContract> GetAllStudent()
            {
              if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
                return null;            
              var query = (from a in ctx.Students
                             select a).Distinct();
    
                List<StudentDataContract> studentList = new List<StudentDataContract>();
    
                query.ToList().ForEach(rec =>
                {
                    studentList.Add(new StudentDataContract
                    {
                        StudentID = Convert.ToString(rec.StudentID),
                        Name = rec.Name,
                        Email = rec.Email,
                        EnrollYear = rec.EnrollYear,
                        Class = rec.Class,
                        City = rec.City,
                        Country = rec.Country
                    });
                });
                return studentList;
            }

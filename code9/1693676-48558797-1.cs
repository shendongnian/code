        [HttpPost]
        public async void Post()
        {
            var form = Request.Form;
            var studentValues = default(StringValues);
            form.TryGetValue("student", out studentValues);
            var student = JsonConvert.DeserializeObject<Student>(studentValues.ToString());
            var insideStudent = _dbContext.Students.FirstOrDefault(cus => cus.Id == student.Id);
            if (insideStudent != null)
            {
                insideStudent.FirstName = student.FirstName;
                insideStudent.LastName = student.LastName;
                _dbContext.SaveChanges();
            }
            else
            {
                var newStudent = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName
                };
                if(form.Files.Any())
                {
                    using (var stream = new MemoryStream())
                    {
                        await form.Files[0].CopyToAsync(stream);
                        newStudent.Avatar = stream.ToArray();
                    }
                }
                _dbContext.Students.Add(newStudent);
                _dbContext.SaveChanges();
            }
        }

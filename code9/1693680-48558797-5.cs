        [HttpPost]
        public async void Post([FromForm]Student student)
        {
            var form = Request.Form;
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

                var student = _dbContext.Set<Student>.where(x => x.Name == filter.Name && x.family == filter.family);
                if (student != null)
                {
                    studentList.Add(student);
                }
            }

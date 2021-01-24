    FilteredList = Students.Where(s => s.Name.Contains(studentNameFilter))
        .Select(s => new Student() 
            { 
                Name = s.Name,
                subjects = s.Subjects.Where(sub => sub.Name.Contains(subjectNameFilter))
            });

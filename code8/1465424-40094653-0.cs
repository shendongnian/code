    var itemss = filteredstudents
        .Where(s => s.SubjectTypes.Any(st => st.SubjectItem.Any(si => si.Name  == value1)))
        .Select(s => new StudentDTO
        {
            Name = s.Name,
            Age = s.Age,
            SubjectTypes = s.SubjectTypes.Where(st => st.SubjectItem.Any(si => si.Name  == value1))
                .Select(st => new SubjectType
                {
                    Id = st.Id,
                    Description = st.Description,
                    SubjectItem = st.SubjectItem.Where(si => si.Name == value1).ToList()
                }).ToList()
        })
        .ToList();

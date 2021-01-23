    var items = filteredstudents.Select(s => new StudentDTO
    {
        Name = s.Name,
        SubjectTypes = s.SubjectTypes.Select(st => new SubjectType
        {
            Description = st.Description,
            SubjectItems = st.SubjectItems.Where(si => si.Name == "AAA").ToList()
        }).Where(x => x.SubjectItems.Count > 0).ToList()
    });

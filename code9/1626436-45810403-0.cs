    var predicates = new List<Expression<Func<Student, bool>>>
    {
        x => x.Type == "Student",
        x => x.Type == "High",
        x => x.Type == "123abc",
        x => x.Type == "Y",
    };
    
    Student student = null;
    for(var i = 0; i < predicates.Count; i++)
    {
        var query = db.Students.AsQueryable();
        for (var j = 0; j < predicates.Count - i; j++)            
            query = query.Where(predicates[j]);
    
        student = query.FirstOrDefault();
        if (student != null)
            break;
    }

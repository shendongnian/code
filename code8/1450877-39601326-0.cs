    persons.GroupBy(p => new { p.FirstName, p.LastName })
    .Select(p => new { 
    p.Key.FirstName, 
    p.Key.LastName, 
    AgeCount = p.Where(p1 => p1.Age != null).Select(p1 => p1.Age).Count() });

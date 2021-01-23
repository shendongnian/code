    var elements = new[]
    {
        new { Name = "A", Date = DateTime.Parse("10/04/2016") },
        new { Name = "A", Date = DateTime.Parse("10/03/2016") },
        new { Name = "A", Date = DateTime.Parse("10/05/2016") },
        
        new { Name = "B", Date = DateTime.Parse("10/02/2016") },
        new { Name = "B", Date = DateTime.Parse("10/01/2016") },
        new { Name = "B", Date = DateTime.Parse("10/03/2016") },
        
        new { Name = "C", Date = DateTime.Parse("10/05/2016") },
        new { Name = "C", Date = DateTime.Parse("10/02/2016") },
        new { Name = "C", Date = DateTime.Parse("10/04/2016") },
    };
    
    // LINQ to Objects
    elements
        .GroupBy(e => e.Name)                         // grouping by name                
        .Select(group => group.OrderBy(e => e.Date))  // order elements by date      
        .OrderBy(group => group.First().Date)         // order groups by date
        .SelectMany(group => group);                  // compose groups 
    // LINQ to Entities
    elements
        .GroupBy(e => e.Name)
        .Select(group => group.OrderBy(e => e.Date))
        .OrderBy(group => group.FirstOrDefault().Date)                   
        .AsEnumerable()
        .SelectMany(group => group);

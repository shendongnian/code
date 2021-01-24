    var groups = ctx.Foo
         .GroupBy(x => x.Type) // Group
         .SelectMany(g => g.Take(5)) // Ungroup
         .Include(x => x.Bar) // Include all other entities
         .AsEnumerable() // Switch to LINQ to Objects
         .GroupBy(x => x.Type) // Group again     
         .Select(g => new FooGroup() // Project
         {
             Type = g.Key,
             Foos = g.Select(x => new FooViewModel(x)).ToList()
         })
         .ToList();

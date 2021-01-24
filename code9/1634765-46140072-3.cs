    IEnumerable<Table> content = /* get it from DbContext */;
    var random = new Random();
    
    var result = content
        .Select(c =>
        { 
            var strings = new[]
                {
                    c.Content1,
                    c.Content2,
                    c.Content3,
                    c.Content4,
                }.OrderBy(x => random.Next()) // randomize columns
                .ToArray();
            return new Table
            {
                MainContent = c.MainContent,
                Content1 = strings[0],
                Content2 = strings[1],
                Content3 = strings[2],
                Content4 = strings[3],
            };
        })
        .OrderBy(x => random.Next());  // randomize rows

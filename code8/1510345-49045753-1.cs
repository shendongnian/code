    var query = context.Top
        .Select(t => new {
            prop1 = t.C1,
            prop2 = t.Sub.Select(s => new {
                prop21 = s.C3
            })
            .ToList() // <-- Add this
        });
    var res = query.ToArray(); // Execute the Linq query

    var q = ...        // your query here
            .ToList(); // Bring results to memory
    decimal total = q.Sum(r => r.IdCount);
    var res = q.Select(r => new {
        r.Color
    ,   r.IdCount
    ,   Percentage = 100 * r.IdCount / total;
    });

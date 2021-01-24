    var results = entities.GroupBy(a => a.UserName(
        .Where(g => !g.Any(a => a.IsCorrect))
        .SelectMany(g => g.Select(a => 
              new {
                   username = a.username,
                   answer = a.answer,
                   ...
              }
         ))
        .Distinct()
        .ToList();

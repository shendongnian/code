    List<statistics> source = ...;
    var result = source
      .SelectMany(item => item.Title
         .Split(',')
         .Select(title => new statistics() {
            Type = item.Type,
            Title = title,
            Flag = item.Flag }))
      .ToList(); // finally, materialize into list

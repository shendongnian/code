    List<statistics> source = .....;
    var result = source
      .SelectMany(item => item.Title //split title 
         .Split(',')
         .Select(title => new statistics() {
            Type = item.Type,
            Title = title,
            Flag = item.Flag }))
      .ToList(); // finally, materialize into list

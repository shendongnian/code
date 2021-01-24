    // Important: only call DateTime.Now once, so that all the values are
    // consistent.
    // Note that this will be the system local time - in many, many cases
    // it's better to use UtcNow.
    var now = DateTime.Now;
    var times = Enumerable.Range(0, 998)
                          .Select(index => now.AddMinutes(index * -15))
                          .ToArray();

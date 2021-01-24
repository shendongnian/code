    // flatten
    var result = list.SelectMany(c => new[] {
        // always include HolidayDate, it's not nullable
        new {
            Date = c.HolidayDate,
            Instance = c
        },
        // include replacement date if not null
        c.ReplacementDate != null ? new {
            Date = c.ReplacementDate.Value,
            Instance = c
        }: null
    })
    // filter out null items (that were created for null replacement dates)
    .Where(c => c != null)
    .GroupBy(c => c.Date)
    .Where(c => c.Count() > 1)
    .ToArray();
    
    // keys of groups are duplicate dates
    var duplcateDates = String.Join(", ", result.Select(c => c.Key.ToString("yyyy-MM-dd")));
    
    var reultString = string.Join(", ", 
          // flatten groups extracting all items
          result.SelectMany(c => c)
          // filter out duplicates
         .Select(c => c.Instance).Distinct()
         .Select(c => c.Description));

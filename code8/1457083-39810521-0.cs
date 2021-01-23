      DateTime date;
    
      var records = csvLinesData
        .GroupBy(line => line[0]) // line[0] is version we want to group by on
        .Select(chunk => new ReleaseVersion() {
           Version = chunk.Key,
           ReleaseDate = DateTime.TryParse(chunk.First()[1], out date) ? date : null,
           ReleaseNotes = chunk
             .Select(item => new ReleaseNote() {
                Description = item[2],
                Progress = item[3],
                Status = item[4], }) 
             .ToArray(), })
        .ToList(); 

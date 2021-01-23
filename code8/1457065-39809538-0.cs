    return csvLinesData.Select(data => {
       DateTime d;
       return new ReleaseNote
       {
         Version = data[0],
         ReleaseDate = DateTime.TryParse(data[1], out d) ? d : DateTime.MinValue
       }
    }).ToList();

    var results = Movies.AsQueryable()
     .SelectMany( x => x.Actors )
     .GroupBy( x => x.Name )
     .Select( x => new { Name = x.Key, ImgUrl = x.First().ImageUrl })
     .ToArray();

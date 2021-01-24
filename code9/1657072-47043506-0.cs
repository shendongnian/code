    var orderByAnonType = db.Select(db.From<Track>().OrderBy(x => new { x.Album, x.Name }));
    
    var orderByString = db.Select(db.From<Track>().OrderBy("Album,Name"));
    
    var orderByArray = db.Select(db.From<Track>().OrderBy(x => new[]{ "Album","Name" }));

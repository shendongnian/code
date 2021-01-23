    var Places = db.Places.Select(x => new { Id = x.Id, Nam1 = x.Name1, Name2 = x.Name2).ToList();
    foreach (var thisPlace in Places)
    {
      Response.Write(thisPlace.Id)
      Response.Write(thisPlace.Name1)
      Response.Write(thisPlace.Name2)
    }

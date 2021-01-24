    // When you DO want to load it
    var x = context.X.Find(id);
    // When you DON'T want to load it
    var x = context.X
        .Where(y => y.Id == id)
        .Select(y => new X /* Or a ViewModel */ { Id = y.Id, ... }) // all properties but Description
        .FirstOrDefault();

    var genres = new[]
    {
        new Genre {Id = 1, Name = "Test Genre 1", ParentId = null},
        new Genre {Id = 2, Name = "Test Genre 2", ParentId = null},
        new Genre {Id = 3, Name = "Test Genre 3", ParentId = 1},
        new Genre {Id = 4, Name = "Test Genre 4", ParentId = 2},
        new Genre {Id = 5, Name = "Test Genre 5", ParentId = 3}
    };
    var result = genres.Select(g => SelectGenreName(genres,g));
    foreach(var r in result)
        Console.WriteLine(r);

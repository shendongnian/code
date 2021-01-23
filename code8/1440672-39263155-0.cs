    var query = Collection<TestFile>()
        .Aggregate()
        .Group(
            t => t.AuthorName,
            grp => new { Count = grp.Count() }
         )
         .ToEnumerable();

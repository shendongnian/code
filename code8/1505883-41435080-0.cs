    var c = ac.Communities.OrderBy(o => o.Posts.Count())
            .Skip(page*limit)
            .Take(limit)
            .ToArray() // This will return a Community array
            .Select(o => o.ToViewModel()) // This is a IEnumerable<CommunityModel>
            .ToArray(); // This will cast // This is a cast for Community array

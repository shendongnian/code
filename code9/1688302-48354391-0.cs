    var result = context.PostInfoes
        .Where(x => x.UserId == userId)
        .Select(x => new { Info = x, LikeCount = x.LikeInfoes.Count() })
        .AsEnumerable()
        .Select(x =>
        {
            x.Info.LikeCount = x.LikeCount;
            return x.Info;
        })
        .ToList();

    var v = db.QuestionTags
        .GroupBy(n => n.Tag.Tag1)
        .Select(n => new Tags {
            Tag = n.Key,
            TagCount = n.Count(),
            TagId = n.First().TagId,
            TagLink = n.First().TagLink
        })
        .OrderByDescending(n => n.TagCount);

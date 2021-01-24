    var v = db.QuestionTags
        .GroupBy(n => new {n.Tag.Tag1, n.TagId, n.TagLink})
        .Select(n => new Tags {
            Tag = n.Key.Tag1,
            TagCount = n.Count(),
            TagId = n.Key.TagId,
            TagLink = n.Key.TagLink
        })
        .OrderByDescending(n => n.TagCount);

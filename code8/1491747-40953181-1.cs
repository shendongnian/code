    var groupedData = allFaqItemsInSelectedSytem
        .GroupBy(e => e.FaqTopicName)
        .Select(g => new
        {
            topicName = g.Key,
            items = g.Select(e => new { e.Answer, e.Question, e.SortOrder }).ToList()
        }).ToList();

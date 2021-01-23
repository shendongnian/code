    var groupedData = 
        (from e in allFaqItemsInSelectedSytem
         group e by e.FaqTopicName into g
         select new
         {
            topicName = g.Key,
            items = (from e in g select new { e.Answer, e.Question, e.SortOrder }).ToList()
         }).ToList();

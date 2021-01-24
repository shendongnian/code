    finalResult.GroupBy(item => item.Points)
               .OrderDescendingBy(g => g.Key)
               .Select((g, index) => new { Data = g, GroupRank index }).
               .SelectMany(g => g.Data.Select(item => new RankingEntity
               {
                   /* properties of each item */
                   Rank = g.GroupIndex
               });

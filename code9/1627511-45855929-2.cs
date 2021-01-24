    finalResult.GroupBy(item => item.Points) // Group by points
               .OrderDescendingBy(g => g.Key) // Order the groups
               .Select((g, index) => new { Data = g, GroupRank = index + 1}) // Rank each group
               .SelectMany(g => g.Data.Select(item => new RankingEntity
               {
                   /* properties of each item */
                   Rank = g.GroupIndex
               }); // Flatten groups and set for each item the group's ranking

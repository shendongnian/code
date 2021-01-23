    List<Message> finalList = new List<Message>();
    
    // First, group all elements with similar size and rate
    var groupedMessages = orderedMessages.GroupBy(m => new { m.Size, m.Rate });
    
    // Now bring them into the correct order by their size and rate
    groupedMessages = groupedMessages.OrderBy(gm => gm.Key.Rate).ThenBy(gm => gm.Key.Size);
    
    // Now sort by similarity within each group
    foreach (var gm in groupedMessages)
    {
        List<string> baseStringList = gm.First().StringList;
                    
        var orderedGroupEntries = gm.OrderBy(
            m => FindExactMatrixSimilarity(baseStringList, m.StringList));
        // This will add to the result list in the correct order
        finalList.AddRange(orderedGroupEntries);
    }

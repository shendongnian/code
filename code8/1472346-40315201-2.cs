     List<string> lines = new List<string> { "1", "2", "3", "1", "4", "5", "4", "4", "6", "7", "8", "3", "9" };
    
                var duplicateIndexes = lines.Select((name, index) => new { name, index })
                // select list items name and index
                                .GroupBy(g => g.name)
                // group them with their name
                                .Where(g => g.Count() > 1)
                // if name counts more than one
                                .SelectMany(g => g.Skip(1), (g, item) => item.index);
                // select but skip first one, because if we need to 
                // count the number as duplicate we should see it before
                // so first number we see is not a duplicate.
                foreach (var item in duplicateIndexes.OrderBy(v=> v))
                {
                    lines[item] = "null"; // we can't directly remove because indexes changes so I decide to set a null string
                    lines[item + 1] = "null"; // you said after first duplicate the item should be removed also, ok item + 1 then
                }
                lines.RemoveAll(x => x == "null"); // then remove all nulls

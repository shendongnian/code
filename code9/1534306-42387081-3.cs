    // Get the VariantId's of the first and last items in the list to be merged
    var firstID = List2.VariantsRanks.First().VariantId;
    var lastID = List2.VariantsRanks.Last().VariantId;
    // Get the indexers of those items in the original list
    var firstIndex = List1.VariantsRanks.FindIndex(x => x.VariantId == firstID);
    var lastIndex = List1.VariantsRanks.FindIndex(x => x.VariantId == lastID);
    if (firstIndex > lastIndex) // in case they are in descending order
    {
        var temp = lastIndex;
        lastIndex = firstIndex;
        firstIndex = temp;
    }
    // Remove matches from the original list
    for (int i = firstIndex; i < lastIndex + 1; i++)
    {
        List1.VariantsRanks.RemoveAt(firstIndex);
    }
    // Inset the items from the list to be merged
    for(int i = 0; i < List2.VariantsRanks.Count; i++)
    {
        List1.VariantsRanks.Insert(firstIndex + i, List2.VariantsRanks[i]);
    }
    / Re-number the Rank
    for(int i = 0; i < List1.VariantsRanks.Count; i++)
    {
        List1.VariantsRanks[i].Rank = i;
    }

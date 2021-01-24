    // Get the VariantId values of the list to be merged
    var ids = List2.VariantsRanks.Select(x => x.VariantId);
    // Remove any matches from the existing list
    List1.VariantsRanks.RemoveAll(x => ids.Contains(x.VariantId));
    // Calculate the current highest rank
    int highestOrder = (List1.VariantsRanks.Max(x => x.Rank));
    foreach (var rank in List2.VariantsRanks)
    {
        // Update the rank
        rank.Rank = ++highestOrder; // pre-increment
        // Add to the existing list
        List1.VariantsRanks.Add(rank);
    }

    string Example()
    { 
        CardSetWithWordCount firstMatch = null;
        foreach (var match in cardSetWithWordCounts.Where(x => x.IsToggled))
        {
            if (firstMatch != null)
            {
                // We've seen one element before, so this is the second one.
                return "mixed";
            }
            firstMatch = match;
        }
        // We get here if there are fewer than two matches. The variable
        // value will be null if we haven't seen any matches, or the first
        // match if there was exactly one match. Use the null conditional
        // operator to handle both easily.
        return firstMatch?.Name;
    }

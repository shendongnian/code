    // No need for Queryables. The function already returns Dictionary which is already an IEnumerable.
    var englishResources = GetAllResourceValues(1);
    var arabicResources = GetAllResourceValues(2);
    // Start with all the english words.
    // Use dictionary because it has efficient key matching.
    var merged = englishResources.ToDictionary( 
        i => i.Key, 
        i => new LanguageResourceModel { 
                Name = i.Key, 
                EnglishValue = i.Value.Value 
            });
    
    // Now merge the arabic ones. 
    // You could LINQ-ify the whole thing, but it's not gonna make it more efficient.
    LanguageResourceModel found;
    foreach (var item in arabicResources)
    {
        // If value already exists, update it
        if (merged.TryGetValue(item.Key, out found))
            found.ArabicValue = item.Value.Value;
        else // Otherwise, add a new one
            merged[item.Key] = new LanguageResourceModel { 
                Name = item.Key, 
                ArabicValue = item.Value.Value 
            };
    }

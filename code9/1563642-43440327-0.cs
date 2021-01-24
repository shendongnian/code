    var stringSet = new HashSet<string>(stringValues);
    var filtered = customTypes.Where(item => dictionary.ContainsKey(item.Id))
                              .Where(item => stringSet.Contains(dictionary[item.Id]));
      
    foreach (var item in filtered)
    {
        item.IsCorrect = true;
    }

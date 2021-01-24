    private static void AddLastNameOrMiddleNameCondition(DirectorySearchData searchData)
    {
      if (!string.IsNullOrWhiteSpace(searchData.LastName))
      {
        var lastNameOrMiddleName = PredicateBuilder.Or(
          (DirectorySearchData entry) => entry.LastName.ToLower().Contains(searchData.LastName.ToLower()),
          (DirectorySearchData entry) => entry.MiddleName.ToLower().Contains(searchData.LastName.ToLower()));
        _conditionsList.Add(lastNameOrMiddleName);
      }
    }

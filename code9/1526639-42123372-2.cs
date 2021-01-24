    private static void AddLastNameOrMiddleNameCondition(DirectorySearchData searchData)
    {
      if (!string.IsNullOrWhiteSpace(searchData.LastName))
      {
        var inner = PredicateBuilder.New<DirectorySearchData>(false);
        // BTW, Use New<T> insted of PredicateBuilder.False<DirectorySearchData>(); methods False<T> and True<T> are obsolete.
        inner = inner.Or(entry => entry.LastName.ToLower().Contains(searchData.LastName.ToLower()));
        inner = inner.Or(entry => entry.MiddleName.ToLower().Contains(searchData.MiddleName.ToLower()));
        _conditionsList.Add(inner);
      }
    }

    string FirstMatchingIdDepthFirst(IEnumerable<ITreeCat> categories, string idToMatch)
    {
      foreach(var cat in categories)
      {
        if (cat.id == idToMatch)
          return cat.name;
        string subResult = FirstMatchingIdDepthFirst(cat.subcat, idToMatch);
        if(subResult != null)
          return string.Format("{0} > {1}", cat.name, subResult);
      }
      return null;
    }

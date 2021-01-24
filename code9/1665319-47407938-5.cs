    public interface ITreeCat
    {
      string id { get; }
      string name { get; }
      IEnumerable<ITreeCat> subcat { get; }
    }
    // add explicit interface implemetantion to existing 3 classes
    // e.g.
    // IEnumerable<ITreeCat> ITreeCat.subcat { get { return subsubcat; } }
    // IEnumerable<ITreeCat> ITreeCat.subcat { get { return Enumerable.Empty<ITreeCat>(); } }
    IEnumerable<string> MyFunc(IEnumerable<ITreeCat> categories, string idToMatch, string prefix = "")
    {
      return (from cat in categories
              where cat.id == idToMatch
              select prefix + cat.name)
        .Concat(from cat in categories
                from recursiveResult in MyFunc(cat.subcat, idToMatch, prefix + cat.name + " > ")
                select recursiveResult);
    }
    IEnumerable<string> MyFunc2(IEnumerable<ITreeCat> categories, string idToMatch, string prefix = "")
    {
      return categories.Where(cat => cat.id == idToMatch)
                       .Select(cat => prefix + cat.name)
                       .Concat(categories.SelectMany(cat => MyFunc2(cat.subcat, idToMatch, prefix + cat.name + " > ")));
    }

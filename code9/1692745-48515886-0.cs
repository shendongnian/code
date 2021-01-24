    using System.Linq;
    ...
    public class SequenceComparer<T> : IEqualityComparer<IEnumerable<T>> {
      public bool Equals(IEnumerable<T> x, IEnumerable<T> y) {
        return Enumerable.SequenceEqual(x, y);
      }
      //TODO: Suboptimal HashCode implementation
      public int GetHashCode(IEnumerable<T> obj) {
        return obj == null
          ? 0 
          : obj.Count(); 
      }
    }
...
    var stringLists = new List<string>() {
      new List<string> {"a", "b", "c"},
      new List<string> {"e", "b", "c"},
      new List<string> {"a", "b", "c"} };
    // All you have to do is to put Distinct
    var result = stringLists
      .Distinct(new SequenceComparer<string>())
      .ToList(); // If you want materialization

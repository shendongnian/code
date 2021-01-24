      // partial: often we have many extensions on collections (Tree, Aggregations etc.) 
      // which are implemented in different files
      public static partial class EnumerableExtensions {
        // IEnumerable<T> - choose argument's type being as much generic and basic as you can
        public static List<T> ToDinamic<T>(this IEnumerable<T> source) {
          // Validate argument(s)
          if (null == source)
            throw new ArgumentNullException(nameof(source)); // or return null or empty list 
          return new List<T>(source);
        }
      }

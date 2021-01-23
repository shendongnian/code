      public static partial class EnumerableExtensions {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source) {
          return source ?? Enumerable.Empty<T>();
        }
      }

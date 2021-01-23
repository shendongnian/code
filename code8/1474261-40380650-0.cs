      public static partial class EnumerableExtensions {
        public static IEnumerable<T> EnsureCount<T>(this IEnumerable<T> source, int count) {
          if (null == source)
            throw new ArgumentNullException("source");
    
          if (count <= 0)
            foreach (var item in source)
              yield return item;
          else {
            List<T> buffer = new List<T>(count);
            
            foreach (var item in source) {
              if (buffer == null)
                yield return item;
              else {
                buffer.Add(item);
    
                if (buffer.Count >= count) {
                  foreach (var x in buffer)
                    yield return x;
    
                  buffer = null;
                }
              }
            }
          }
        }
      } 

    public static IEnumerable<T> Intersect2<T>(IEnumerable<T> source, IEnumerable<T> target)
        {
             List<T> list = target.ToList();
             foreach (T item in source)
             {
                 if (list.Contains(item))
                 {
                    list.Remove(item);
                    yield return item;
                 }
              }
        }

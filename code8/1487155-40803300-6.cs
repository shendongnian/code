    private class ElementAndIndex<T>
    {
      public T Element { get; set; }
      public int Index { get; set; }
    }
    public static IQueryable<T> BeforeLastMatch<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      // If source is actually an in-memory enumerable, the other method will be more efficient,
      // so use it instead.
      var asEnum = source as EnumerableQuery<T>;
      if (asEnum != null && asEnum.Expression.NodeType == ExpressionType.Constant)
      {
        // On any other IQueryable calling `AsEnumerable()` will force it
        // to be loaded into memory, but on an EnumerableQuery it just
        // unwraps the wrapped enumerable this will chain back to the
        // contained GetEnumerator.
        return BeforeLastMatchImpl(source.AsEnumerable(), predicate.Compile()).AsQueryable();
      }
      
      // We have a lambda from (T x) => bool, and we need one from
      // (ElementAndIndex<T> x) => bool, so build it here.
      
      var param = Expression.Parameter(typeof(ElementAndIndex<T>));
      var indexingPredicate = Expression.Lambda<Func<ElementAndIndex<T>, bool>>(
        Expression.Invoke(predicate, Expression.Property(param, "Element")),
        param
      );
      
      return source.Take( // We're going to Take based on the last index this finds.
        source
          // Elements and indices together
          .Select((x, i) => new ElementAndIndex<T>{ Element = x, Index = i}) 
          // The new predicate we created from that passed to us.
          .Where(indexingPredicate)
          // The last matching element.
          .Select(x => x.Index).Last());
    }

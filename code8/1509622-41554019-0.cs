    public static IEnumerable<TResult> LeftJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,                                                 IEnumerable<TInner> inner, Func<TSource, TKey> pk, Func<TInner, TKey> fk, Func<TSource, TInner, TResult> result)
        {
            IEnumerable<TResult> _result = Enumerable.Empty<TResult>();
         
            _result = from s in source
                      join i in inner
                      on pk(s) equals fk(i) into joinData
                      from left in joinData.DefaultIfEmpty()
                      select result(s, left);
         
            return _result;
        }  

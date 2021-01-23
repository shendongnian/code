        public static IQueryable<TResult> Select<TSource,TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector) {
            if (source == null)
                throw Error.ArgumentNull("source");
            if (selector == null)
                throw Error.ArgumentNull("selector");
            return source.Provider.CreateQuery<TResult>( 
                Expression.Call(
                    null,
                    GetMethodInfo(Queryable.Select, source, selector),
                    new Expression[] { source.Expression, Expression.Quote(selector) }
                    ));
        }

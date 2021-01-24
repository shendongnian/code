        /// <summary>
        /// Implement Left Outer join implemented by calling GroupJoin and
        /// SelectMany within this extension method
        /// </summary>
        /// <typeparam name="TOuter">Outer Type</typeparam>
        /// <typeparam name="TInner">Inner Type</typeparam>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TResult">Result Type</typeparam>
        /// <param name="outer">Outer set</param>
        /// <param name="inner">Inner set</param>
        /// <param name="outerKeySelector">Outer Key Selector</param>
        /// <param name="innerKeySelector">Inner Key Selector</param>
        /// <param name="resultSelector">Result Selector</param>
        /// <returns>IQueryable Result set</returns>
        public static IQueryable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(
           this IQueryable<TOuter> outer,
           IQueryable<TInner> inner,
           Expression<Func<TOuter, TKey>> outerKeySelector,
           Expression<Func<TInner, TKey>> innerKeySelector,
           Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {
            //LinqKit allows easy runtime evaluation of inline invoked expressions
            // without manually writing expression trees.
            return outer
                .AsExpandable()// Tell LinqKit to convert everything into an expression tree.
                .GroupJoin(
                    inner,
                    outerKeySelector,
                    innerKeySelector,
                    (outerItem, innerItems) => new { outerItem, innerItems })
                .SelectMany(
                    joinResult => joinResult.innerItems.DefaultIfEmpty(),
                    (joinResult, innerItem) =>
                        resultSelector.Invoke(joinResult.outerItem, innerItem));
        }

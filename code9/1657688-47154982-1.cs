        public static IQueryable<A> OrderData<A, B>(this IQueryable<A> data, Func<A, B> orderbyClause)
        {
            return data
                    .OrderBy(orderbyClause)
                    .AsQueryable();
        }

        public static IQueryable<T> WhereActive<T>(this IQueryable<T> query)
            where T: BaseObject
        {
            return query.Where(b => !b.IsDeleted);
        }

        private IEnumerable<T> GetList<T>(IDocumentSession session, string sort, 
    Expression<Func<T, object>> keySelectorExp, int? skip, int? take)
        {
            IQueryable<T> query = session.Query<T>();
            if (sort == "asc")
                query = query.OrderBy(keySelectorExp);
            else
                query = query.OrderBy(keySelectorExp);
            if (take.HasValue)
                query = query.Skip(skip ?? 0).Take(take.Value);
            return query.ToList();
        }

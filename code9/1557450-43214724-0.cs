    public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new DbEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            return list;
        }

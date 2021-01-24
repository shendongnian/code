    public IEnumerable<AttestationEntity> GetListWithChildren(Expression<Func<AttestationEntity, bool>> pred)
        {
            using (ScDbContext context = new ScDbContext())
            {
                return this.GetListWithChildrenInternal(context, pred).OrderBy(att => att.CreatedDate).ToList();
            }
        }
        internal IEnumerable<AttestationEntity> GetListWithChildrenInternal(ScDbContext context, Expression<Func<AttestationEntity, bool>> pred)
        {
            return this.GetListInternal(context, pred, attestationChildren).OrderBy(att => att.CreatedDate).ToList();
        }
    internal IEnumerable<E> GetListInternal(DBC context, Expression<Func<E, bool>> where, params Expression<Func<E, object>>[] navigationProperties)
            {
                IQueryable<E> dbQuery = context.Set<E>();
    
                //Apply eager loading
                foreach (Expression<Func<E, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<E, object>(navigationProperty);
    
                return dbQuery
                    //.AsNoTracking() //Don't track any changes for the selected item
                    .Where(where)
                    .ToList(); //Apply where clause
            }

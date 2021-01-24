    public class PersonBusiness<T> : BaseBusiness<T> where T: PersonEntity
    {
        public IQueryable<T> GetQuery(string orderBy, int? groupId)
        {
            IQueryable<T> query = Db.PersonSet.Cast<T>();
            Func<IQueryable<T>, IQueryable<T>> defaultOrderBy = null;
            if (groupId.HasValue)
            {
                query = query.Where(d => d.Id == groupId);
            }
            else
            {
                defaultOrderBy = q => q.OrderBy(d => d.Id).ThenBy(d => d.FullName);
            }
            return GetQuery(query, orderBy, defaultOrderBy);
        }
        public override IQueryable<T> ApplyDefaultOrderyBy(IQueryable<T> query)
        {
            return query.OrderBy(q => q.FullName);
        }
    }

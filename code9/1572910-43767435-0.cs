    public interface IPersonEntity
    {
        int Id { get; set; }
        string FullName { get; set; }
    }
    public class PersonBusiness<T> where T : IPersonEntity
    {
        public IQueryable<T> GetQuery(string orderBy, int? groupId)
        {
            IQueryable<T> query = Db.PersonSet;
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
        public IQueryable<T> ApplyDefaultOrderyBy(IQueryable<T> query)
        {
            return query.OrderBy(q => q.FullName);
        }
        public IQueryable<T> GetQuery(IQueryable<T> query, string orderBy, Func<IQueryable<T>, IQueryable<T>> defaultOrderBy = null)
        {
            if (orderBy != null)
                query = query.OrderBy(orderBy);
            else
                query = defaultOrderBy != null ? defaultOrderBy(query) : ApplyDefaultOrderyBy(query);
            return query;
        }
    }

    public class TagableRepository<T> : Repository<T> where T : class, ITagableEntity
    {
        protected override IQueryable<T> GetQueryable()
        {
            return base.GetQueryable().Where(q => q.tagtoken > 10);
        }
    }

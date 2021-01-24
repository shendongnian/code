    public class AsyncCRUDService<TEntity, TIDTO, TDTO, TAdapter> : IAsyncCRUDService<TDTO>
        where TDTO : TIDTO
        where TEntity : class, new()
        where TAdapter : class, TIDTO, IAdaptable<TEntity, TIDTO, TDTO>
    {
        protected DbContext _context;
        protected TAdapter _adapter;
        public AsyncCRUDService(DbContext context, TAdapter adapter)
        {
            this._context = context;
            this._adapter = adapter;
        }
        public async virtual Task<TDTO> Get(object[] id)
        {
            var entity = await this._context.Set<TEntity>().FindAsync(id);
            if (null == entity)
            {
                throw new InvalidIdException();
            }
            return this.AdaptToDTO(entity);
        }
        protected virtual TDTO AdaptToDTO(TEntity entity)
        {
            this._adapter.Initialize(entity);
            return this._adapter.ToDTO(this._adapter);
        }
    }

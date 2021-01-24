    public abstract class GenericRepository<C, E> : IGenericRepository<T> 
    where E : class
    where C : IdentityDbContext<User>, new()
    {
        //...
        public virtual List<DTO> findBy<DTO>(Expression<Func<DTO, bool>> query = 
         null, Func<IQueryable<DTO>, IOrderedQueryable<DTO>> orderBy = null,
                                        Expression<Func<DTO, bool>> whereIn = 
          null, int? page = null, int? sizePage = null)
        {
            //...transform DTO queries to E queries and Get IQueriable<E> entity 
               from database
            DTO dtoEntity=entity.ProjectTo<DTO>();
            return dtoEntity;                           
        }
    }

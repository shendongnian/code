    public class MyAppService : CrudAppService<ParentEntity, ParentEntityDto>, IMyAppService
    {
        public MyAppService(IRepository<ParentEntity> repository)
            : base(repository)
        {
        }
        protected override IQueryable<ParentEntity> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return Repository.GetAllIncluding(p => p.ChildEntity);
        }
        protected override ParentEntity GetEntityById(int id)
        {
            var entity = Repository.GetAllIncluding(p => p.ChildEntity).FirstOrDefault(p => p.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(ParentEntity), id);
            }
            return entity;
        }
    }

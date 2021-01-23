    public class BaseService<T, TDTO> : IService<T, TDTO> where T : class, IEntity
        where TDTO : class, IEntityDTO
    {
    ....
        public IList<TDTO> GetAll()
        {
            return _mapper.Map<IList<TDTO>>(_repository.GetAll().ToList());
        }
    }

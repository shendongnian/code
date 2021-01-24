    public interface IFilterService
    {
        bool CanHandle(FilterType type);
    
        Task<ServiceResult<T>> FilterAsync<T>(T entity);
    }
    
    public class NameService : IFilterService
    {
        public bool CanHandle(FacetType type)
        {
            return type == FacetType.Name;
        }
    
        public async Task<ServiceResult<T>> FilterAsync<T>(T entity)
        {
          if(!entity is Name)
              throw new NotSupportedException();
          Name entityAsName = (Name)entity;
          // Code
        }
    }

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
    
        public Task<ServiceResult<T>> FilterAsync<T>(T entity)
        {
          if(!entity is Name)
              throw new NotSupportedException("The parameter entity is not assignable to the type Name");
          
            return FilterAsyncInternal((Name)entity);
        }
        private async Task<ServiceResult<Name>> FilterAsyncInternal(Name entity)
        {
            //code
        }
    }

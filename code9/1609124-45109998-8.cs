    public class FilterController
    {
        private readonly IEnumerable<IFilterService<Name>> filters;
    
        public MediaController(IEnumerable<IFilterService<Name>> filters)
        {
            this.filters = filters;
        }
    
         public async Task<HttpResponseMessage> FilterAsync(FilterType type, Name entity)
         {
            foreach(var filter in this.filters.Where(x => x.CanHandle(type)))
            {
                filter.FilterAsync(entity); 
            }
            ....
        }
    }

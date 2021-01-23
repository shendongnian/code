        using using Kendo.Mvc.Extensions;
    
        public IQueryable<vNPISearch> Search(string id, [DataSourceRequest] DataSourceRequest request){
            return !String.IsNullOrEmpty(id) ? oandpService.GetPecosQueryable(id).ToDataSourceResult(request) : Enumerable.Empty<vNPISearch>().AsQueryable().ToDataSourceResult(request);
        }

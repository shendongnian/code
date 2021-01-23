        using using Kendo.Mvc.Extensions;
    
        public ActionResult Search(string id, [DataSourceRequest] DataSourceRequest request){
            return !String.IsNullOrEmpty(id) ? oandpService.GetPecosQueryable(id).ToDataSourceResult(request) : Enumerable.Empty<vNPISearch>().AsQueryable().ToDataSourceResult(request);
        }

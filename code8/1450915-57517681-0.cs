    namespace MyNameSpace
    {
        [System.Web.Http.RoutePrefix("api/Reports")]
        public class ReportsController
        {
            {...constructor...}
            
            [System.Web.Http.Route("Scans")]
            [System.Web.Http.HttpGet,ResponseType(typeof(List<ReportClass>))]
            public ascyn Task<HttpResponseMessage> GetScans() {...}

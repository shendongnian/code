    using System.Web.Http;
    using System.Web.OData;
    using System.Web.OData.Query;
    using System.Web.OData.Routing;
    [ODataRoutePrefix("nominal_accounts")]
    public class NominalAccountsController : ODataController
    {
        [EnableQuery]
        public virtual IQueryable<NominalAccount> Get(ODataQueryOptions<NominalAccount> q)
        {
            return _your_odata_source;
        }
    }

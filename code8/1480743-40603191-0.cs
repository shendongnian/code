    [System.Web.Mvc.RoutePrefix("api/Org")]
    public class OrgController : BaseController
    {
        [HttpPost]
        public IEnumerable<Organization> Get()
        {
            Db.Configuration.LazyLoadingEnabled = false;
            return Db.Organizations.ToList();
        }
    }

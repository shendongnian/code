    using System.Collections.Generic;
    using System.Linq;
    using Batch.OData;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNet.OData.Query;
    
    namespace Batch.Controllers
    {
    public class CapacityRiskController : ODataController
    {
        private readonly List<CapacityRisk> _feed = new List<CapacityRisk>();
        public CapacityRiskController()
        {
            foreach (var i in Enumerable.Range(0, 100))
            {
                _feed.Add(new CapacityRisk { Ipn = i.ToString() });
            }
        }
        public PageResult<CapacityRisk> Get(ODataQueryOptions<CapacityRisk> options)
        {
            var skip = options?.Skip?.Value ?? 0;
            var results = _feed.Skip(skip).Take(10);
            return new PageResult<CapacityRisk>(
                results,
                Request.GetNextPageLink(10),
                Request.ODataFeature().TotalCount);
        }
    }
    }

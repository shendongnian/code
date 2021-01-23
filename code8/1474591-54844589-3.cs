    public class ThingController : ODataController
    {
        [HttpGet]
        public PageResult<Thing> GetThings(ODataQueryOptions<Thing> queryOptions)
        {
            var thingsToSkip = queryOptions?.Skip?.Value ?? 0;
            var pageSize = 10;
            var totalThings = GetThingCount();
            var pageOfThings = GetThings(thingsToSkip, pageSize);
            var showNextLink = thingsToSkip + pageOfItems.Count < totalThings;
            return new PageResult<Things>(pageOfThings,
                showNextLink ? Request.GetNextPageLink(pageSize) : null,
                totalThings);
        }
        private int GetThingCount()
        {
            return 21;
        }
        private List<Things> GetThings(int skip, int take)
        {
            return Enumerable.Range(0, TotalThingCount())
                .Select(r => new Thing { Id = r.ToString() })
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    

    public class ForecastComparisonController : ODataController
    {
        [HttpGet]
        public PageResult<ForecastComparison> GetForecastComparison(ODataQueryOptions<ForecastComparison> queryOptions)
        {
            var amountToSkip = queryOptions?.Skip?.Value ?? 0;
            var pageSize = 10;
            var totalItems = TotalItemCount();
            var pageOfItems = GetItems(amountToSkip, pageSize);
            var showNextLink = amountToSkip + pageOfItems.Count < totalItems;
            return new PageResult<ForecastComparison>(pageOfItems,
                showNextLink ? Request.GetNextPageLink(pageSize) : null,
                totalItems);
        }
        private int TotalItemCount()
        {
            return 21;
        }
        private List<ForecastComparison> GetItems(int skip, int take)
        {
            return Enumerable.Range(0, TotalItemCount())
                .Select(r => new ForecastComparison { Ipn = r.ToString() })
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    

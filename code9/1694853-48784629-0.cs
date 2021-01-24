    public sealed class PagingAttribute : EnableQueryAttribute
    {
        public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
        {
            var result = default(IQueryable);
            var originalRequest = queryOptions.Request;
            var skip = queryOptions.Skip == null ? 0 : queryOptions.Skip.Value;
            var take = queryOptions.Top == null ? PageSize : queryOptions.Top.Value;
            queryOptions = ODataQueryOptionsUtilities.Transform(queryOptions, new ODataQueryOptionsUtilitiesTransformSettings { Skip = (map, option) => default(int?) });
            if (queryOptions.Request.ODataProperties().TotalCount != null)
                originalRequest.ODataProperties().TotalCount = originalRequest.GetInlineCount();
              
            result = queryOptions.ApplyTo(queryable);
            if (skip + take <= originalRequest.ODataProperties().TotalCount)
                originalRequest.ODataProperties().NextLink = NextPageLink.GetNextNewPageLink(originalRequest, (skip + take));
            return result;
        }
    }

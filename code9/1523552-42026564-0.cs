    public static class UrlHelperExtensions
    {
        public static string Page(this IUrlHelper url, int page, int pageSize)
        {
            //Reuse existing route values
            RouteValueDictionary resultRouteValues = new RouteValueDictionary(url.ActionContext.RouteData.Values);
            //Add existing values from query string
            foreach (var queryValue in url.ActionContext.HttpContext.Request.Query)
            {
                if(resultRouteValues.ContainsKey(queryValue.Key))
                    continue;
                
                resultRouteValues.Add(queryValue.Key, queryValue.Value);
            }
            //Set or add values for PagedList input model
            resultRouteValues[nameof(PagedListInputModel.Page)] = page;
            resultRouteValues[nameof(PagedListInputModel.PageSize)] = pageSize;
            return url.RouteUrl(resultRouteValues);
        }
    }

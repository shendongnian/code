    [AttributeUsage(validOn: AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class EnableQueryAttribute : System.Web.OData.EnableQueryAttribute
    {
        public EnableQueryAttribute()
        {
            // TODO: Reset default values
        }
            
        /// <summary>
        /// Intercept before the query, here we can safely manipulate the URL before the WebAPI request has been processed so before the OData context has been resolved.
        /// </summary>
        /// <remarks>Simple implementation of common url replacement tasks in OData</remarks>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var tokens = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.AbsoluteUri);
            // If the caller requested oDataV2 $inlinecount then remove it!
            if (tokens.AllKeys.Contains("$inlinecount"))
            {
                // CS: we don't care what value they requested, OData v4 will only return the allPages count
                tokens["$count"] = "true";
                tokens.Remove("$inlinecount");
            }
            // if caller forgot to ask for count and we are top'ing but paging hasn't been configured lets add the overall count for good measure
            else if (String.IsNullOrEmpty(tokens["$count"])
                && !String.IsNullOrEmpty(tokens["$top"])
                && this.PageSize <= 0
            )
            {
                // we want to add $count if it is not there
                tokens["$count"] = "true";
            }
                        			
            var modifiedUrl = ParseUri(tokens);
                        
            // if we modified the url, reset it. Leaving this in a logic block to make an obvious point to extend the process, say to perform other clean up when we know we have modified the url
            if (modifiedUrl != actionContext.Request.RequestUri.AbsoluteUri)
                actionContext.Request.RequestUri = new Uri(modifiedUrl);
                        
            base.OnActionExecuting(actionContext);
        }
            
        /// <summary>
        /// Simple validator that can fix common issues when converting NameValueCollection back to Uri when the collection has been modified.
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        private static string ParseUri(System.Collections.Specialized.NameValueCollection tokens)
        {
            var query = tokens.ToHttpQuery().TrimStart('=');
            if (!query.Contains('?')) query = query.Insert(query.IndexOf('&'), "?");
            return query.Replace("?&", "?");
        }
            
        /// <summary>
        /// Here we can intercept the IQueryable result AFTER the controller has processed the request and created the intial query.
        /// </summary>
        /// <remarks>
        /// So you could append filter conditions to the query, but, like middleware you may need to know a lot about the controller 
        /// or you have to make a lot of assumptions to make effective use of this override. Stick to operations that modify the queryOptions 
        /// or that conditionally modify the properties on this EnableQuery attribute
        /// </remarks>
        /// <param name="queryable">The original queryable instance from the controller</param>
        /// <param name="queryOptions">The System.Web.OData.Query.ODataQueryOptions instance constructed based on the incomming request</param>
        public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
        {
            // I do not offer common examples of this override, because they would be specific to your business logic, but know that it is an available option
            return base.ApplyQuery(queryable, queryOptions);
        }
    }

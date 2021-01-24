    internal class RedirectCultureRule : IRule
    {
        private const string CultureKey = "culture";
        public void ApplyRule(RewriteContext context)
        {
            HttpRequest httpRequest = context.HttpContext.Request;
            httpRequest.Query.TryGetValue(CultureKey, out StringValues cultureValues);
            string culture = cultureValues;
            if (cultureValues.Count > 0 && culture.IsCultureMatch())
            {
                context.Result = RuleResult.ContinueRules;
                return;
            }
            Dictionary<string, string> queryParts = new Dictionary<string, string>();
            NameValueCollection queryString = HttpUtility.ParseQueryString(httpRequest.QueryString.ToString());
            foreach (string key in queryString)
            {
                queryParts[key.Trim()] = queryString[key].Trim();
            }
            if (!queryParts.ContainsKey(CultureKey))
            {
                queryParts[CultureKey] = CultureInfo.CurrentCulture.Name;
            }
            string query = $"?{string.Join("&", queryParts.Select(qp => $"{qp.Key}={qp.Value}"))}";
            if (query.Length > 1)
            {
                httpRequest.QueryString = new QueryString(query);
            }
            string url = UriHelper.GetDisplayUrl(httpRequest);
            HttpResponse httpResponse = context.HttpContext.Response;
            httpResponse.StatusCode = 308;
            httpResponse.Headers[HeaderNames.Location] = url;
            using (StreamReader requestReader = new StreamReader(httpRequest.Body))
            {
                using (StreamWriter responseWriter = new StreamWriter(httpResponse.Body))
                {
                    string body = requestReader.ReadToEnd();
                    responseWriter.Write(body);
                    responseWriter.Flush();
                }
            }
            context.Result = RuleResult.EndResponse;
        }
    }

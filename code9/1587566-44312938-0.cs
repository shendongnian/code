    private static void RedirectToAPI(RewriteContext context)
    {
        var request = context.HttpContext.Request;
        if (request.Path.Value.StartsWith("/apiendpoint", StringComparison.OrdinalIgnoreCase))
        {           
            var json = JsonConvert.SerializeObject(request.Path.Value
                .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1));
            var response = context.HttpContext.Response;
            response.Headers[HeaderNames.Location] = $"/custom";
            response.StatusCode = 308;
            context.Result = RuleResult.EndResponse;
            using (var bodyWriter = new StreamWriter(response.Body))
            {
                bodyWriter.Write(json);
                bodyWriter.Flush();
            }
        }
    }

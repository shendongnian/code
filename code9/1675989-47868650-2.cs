    public class ActionFilter : ActionFilterAttribute
    {
        public override async Task OnActionExecutedAsync(HttpActionExecutedContext actionContext, CancellationToken cancellationToken)
        {
            await base.OnActionExecutedAsync(actionContext, cancellationToken);
            await GetStackoverflow();
        }
        private async Task GetStackoverflow()
        {
            var request = WebRequest.Create("http://www.stackoverflow.com");
            var response = await Task.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null) as HttpWebResponse;
            // this debug is unreachable if a past filter has implemented async incorrectly
            Debug.Assert(response?.StatusCode == HttpStatusCode.OK);
        }
    }

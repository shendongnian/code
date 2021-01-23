    public class FilterResponseWriteModule : IHttpModule, IDisposable
    {
        private System.IO.Stream filterStream;
        
        public FilterResponseWriteModule()
        {
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
        }
        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var context = (sender as HttpApplication).Context;
            if (ShouldApplyFilter(context.Request))
                ApplyFilter(context.Response);
        }
        private bool ShouldApplyFilter(HttpRequest request)
        {
            return string.Equals(request.ContentType, @"text/plain", StringComparison.OrdinalIgnoreCase);
        }
        private void ApplyFilter(HttpResponse response)
        {
            filterStream = new EncodeStreamFilter(response.Filter);
            response.Filter = filterStream;
        }
        public void Dispose()
        {
            if (filterStream != null)
            {
                filterStream.Dispose();
            }
        }
    }

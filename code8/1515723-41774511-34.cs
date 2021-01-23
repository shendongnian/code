    internal class http : Nequeo.Net.Http.CustomContext
    {
        /// <summary>
        /// On new client Http context.
        /// </summary>
        /// <param name="context">The client Http context.</param>
        protected override void OnHttpContext(Nequeo.Net.Http.HttpContext context)
        {
            // Get the headers from the stream and assign the request data.
            bool headersExist = Nequeo.Net.Http.Utility.SetRequestHeaders(context, 30000, 10000);
            context.HttpResponse.ContentLength = 5;
            context.HttpResponse.ContentType = "text/plain";
            context.HttpResponse.StatusCode = 200;
            context.HttpResponse.StatusDescription = "OK";
            context.HttpResponse.WriteHttpHeaders();
            context.HttpResponse.Write("Hello");
        }
    }

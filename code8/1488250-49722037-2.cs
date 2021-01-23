    class AuthenticationPermissionsMiddleware : OwinMiddleware
    {
        public AuthenticationPermissionsMiddleware(OwinMiddleware next) 
            : base(next)
        {            
        }
        public override async Task Invoke(IOwinContext context)
        {
            if (!context.Request.Path.Equals("/Token")
            {
                await Next.Invoke(context);
                return;
            }
            using (var tokenBodyStream = new MemoryStream())
            {
                // save initial OWIN stream
                var initialOwinBodyStream = context.Response.Body;
                // create new memory stream
                context.Response.Body = tokenBodyStream;
                // other middlewares will will update our tokenBodyStream
                await Next.Invoke(context);
                var tokenResponseBody = GetBodyFromStream(context.Response);
                var obj = JsonConvert.DeserializeObject(tokenResponseBody);
                var jObject = JObject.FromObject(obj);
                // add your custom array or any other object
                var scopes = new Scope[];
                jObject.Add("scopes", JToken.FromObject(scopes));
                var bytes = Encoding.UTF8.GetBytes(jObject.ToString());
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                await tokenBodyStream.WriteAsync(bytes, 0, bytes.Length);
                context.Response.ContentLength = data.LongLength;
                tokenBodyStream.Seek(0, SeekOrigin.Begin);
                // get back result to the OWIN stream
                await context.Response.Body.CopyToAsync(initialOwinBodyStream);
                }
            }
        }
        private string GetBodyFromStream(IOwinResponse response)
        {
            using (var memoryStream = new MemoryStream())
            {
                response.Body.Seek(0, SeekOrigin.Begin);
                response.Body.CopyTo(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(memoryStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }

        public override void OnAuthorization(HttpActionContext ctx)
        {            
            if (!VerifyHeaders(ctx))
            {
                ctx.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }
            base.OnAuthorization(ctx);
        }
        private bool VerifyHeaders(HttpActionContext ctx)
        {
            IEnumerable<string> values = new List<string>();
            //Read the API key from the request header
            ctx.Request.Headers.TryGetValues("ApiKey", out values);
            var apiKey = values?.FirstOrDefault();        
            return CheckApiKey(apiKey);
        }
        private bool CheckApiKey(string apiKey)
        {
            //Verification is done here
            return true;
        }

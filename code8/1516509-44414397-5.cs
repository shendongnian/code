     protected string ObtainAppTokenFromHeader(string authHeader)
        {
            if (!authHeader.Contains(" "))
                return null;
            string[] authSchemeAndJwt = authHeader.Split(' ');
            string authScheme = authSchemeAndJwt[0];
            if (authScheme != "Bearer")
                return null;
            string jwt = authSchemeAndJwt[1];
            return jwt;
        }
        protected async Task<bool> AuthorizeUserFromHttpContext(HttpContext context)
        {
            var jwtBearerOptions = context.RequestServices.GetRequiredService<JwtBearerOptions>() as JwtBearerOptions;
            string jwt = this.ObtainAppTokenFromHeader(context.Request.Headers["Authorization"]);
            if (jwt == null)
                return false;
            var jwtBacker = new JwtBearerBacker(jwtBearerOptions);
            return jwtBacker.IsJwtValid(jwt);
        }
        public async Task Invoke(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
                return;
            if (!await this.AuthorizeUserFromHttpContext(context))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("The door is locked, dude. You're not authorized !");
                return;
            }
    //... Whatever else you're doing in your middleware
           }

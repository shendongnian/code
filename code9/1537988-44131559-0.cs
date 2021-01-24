        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowedHosts = "127.0.0.1,192.168.1.15";
            if (
                (allowedHosts.Contains("127.0.0.1")
                && context.HttpContext.Connection.RemoteIpAddress.ToString() == "127.0.0.1"
                && !string.IsNullOrEmpty(context.HttpContext.Request.Headers["X-Forwarded-For"]))
                ||
                (!(context.HttpContext.Request.Host.Host.Contains("localhost"))
                && !allowedHosts.Contains(context.HttpContext.Connection.RemoteIpAddress.ToString()))
                )
            {
                log();
                context.Result =new RedirectResult("/404");
            }
        }

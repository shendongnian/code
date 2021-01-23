    public class RedirectMiddleware
    {
        private readonly RequestDelegate _next;
        public RedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string CountryCodeInUrl = "", redirectUrl = "";
            var countryCode = CookieSettings.ReadCookie();
            if (countryCode == "")
            {
                countryCode = "gb";
            }
            if (context.Request.Path.Value.Length >= 2)
            {
                CountryCodeInUrl = context.Request.Path.Value.Substring(1, 2);
            }
            if (countryCode != CountryCodeInUrl)
            {
                if (context.Request.Path.Value.Length >= 2)
                {
                    if (context.Request.Path.Value.Substring(1, 2) != "")
                    {
                        countryCode = context.Request.Path.Value.Substring(1, 2);
                    }
                }
                if (!context.Request.Path.Value.Contains(countryCode))
                {
                    redirectUrl = string.Format("/{0}{1}", countryCode, context.Request.Path.Value);
                }
                else
                {
                    redirectUrl = context.Request.Path.Value;
                }
                CookieSettings.SaveCookie(countryCode);
                context.Response.Redirect(redirectUrl, true);
            }
            
            await _next.Invoke(context);
        }
    }

        public void Append(string key, string value, CookieOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            var setCookieHeaderValue = new SetCookieHeaderValue(
                Uri.EscapeDataString(key),
                Uri.EscapeDataString(value))
            {
                Domain = options.Domain,
                Path = options.Path,
                Expires = options.Expires,
                MaxAge = options.MaxAge,
                Secure = options.Secure,
                SameSite = (Net.Http.Headers.SameSiteMode)options.SameSite,
                HttpOnly = options.HttpOnly
            };
            var cookieValue = setCookieHeaderValue.ToString();
            Headers[HeaderNames.SetCookie] = StringValues.Concat(Headers[HeaderNames.SetCookie], cookieValue);
        }

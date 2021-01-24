    public static string GetRequestIp()
        {
            if (HttpContext.Current.Request.Headers["X-Forwarded-For"] != null)
            {
                return HttpContext.Current.Request.Headers["X-Forwarded-For"].Split(new char[] { ',' })[0].ToString();
            }
            return HttpContext.Current.Request.UserHostAddress;
        }

    string[] allDomainCookes = HttpContext.Current.Request.Cookies.AllKeys;
        foreach (string domainCookie in allDomainCookes)
        {
            if (domainCookie.Contains("ASPXAUTH"))
            {
                var expiredCookie = new HttpCookie(domainCookie) { 
                      Expires = DateTime.Now.AddDays(-1),
                      Domain = ".mydomain"
                };
                HttpContext.Current.Response.Cookies.Add(expiredCookie);
            }
        }
        HttpContext.Current.Request.Cookies.Clear();

            foreach (var c in cookieList)
            {
                HttpCookie currentUserCookie = HttpContext.Current.Request.Cookies[c];
                if (currentUserCookie != null)
                {
                    HttpContext.Current.Response.Cookies.Remove(c);
                    currentUserCookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(currentUserCookie);
                }
            }

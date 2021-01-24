    var cookieValue = (json).Replace(";", "").Replace(",", "***");
     if (HttpContext.Current.Request.Browser.Type.ToLower().Contains("safari"))
                {
                    HttpContext.Current.Response.AddHeader("Set-Cookie", sessionName + "=" + cookieValue + "; path=/;");
                }

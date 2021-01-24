    web.PreRequest += request =>
                {
                    CookieContainer cookieContainer = new CookieContainer();
                    string str = Application.GetCookie(uri);
                    foreach (string s in str.Split(';'))
                    {
                        int charIndex = s.IndexOf('=');
                        string a = s.Substring(0, charIndex).Trim();
                        string b = s.Substring(charIndex+1, s.Length - charIndex-1);
                        cookieContainer.Add(new Cookie(a,b) { Domain = uri.Host });
                    }
                    request.CookieContainer = cookieContainer;
                    return true;
                };

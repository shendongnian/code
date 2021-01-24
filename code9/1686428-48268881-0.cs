    internal class Platform : IPlatform
    {
        public void DeleteAllCookies()
        {
            foreach (var c in NSHttpCookieStorage.SharedStorage.Cookies)
            {
                NSHttpCookieStorage.SharedStorage.DeleteCookie(c);
            }
        }
    }

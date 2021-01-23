        public void setFilterCookie(string name, string val)
        {
            var cookieValue = string.Empty;
            var expires = 0;
            if (!string.IsNullOrWhiteSpace(val) && !val.Equals("-1"))
            {
                cookieValue = val;
                expires = 5;
            }
            else
            {
                expires = -2;
            }
            var cookie = new HttpCookie(name, cookieValue) {Expires = DateTime.Now.AddDays(expires)};
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }

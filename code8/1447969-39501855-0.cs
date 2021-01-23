    public interface ICookieManager
        {
            void CreateUserCookie(string userName, string password, HttpResponseBase response, int expiration = 10);
        }
    
        public class CookieManager: ICookieManager
        {
            public void CreateUserCookie(string userName, string password, HttpResponseBase response, int expiration = 10)
            {
                HttpCookie usercookie = new HttpCookie("usercookie");
                usercookie["UserName"] = userName;
                usercookie["Password"] = password;
                usercookie.Expires = DateTime.Now.AddMinutes(expiration);
                response.Cookies.Add(usercookie);
            }
        }

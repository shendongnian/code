    private void AddUserDataToCookies(User user)
        {
            var serializeModel = new WebUserSerializeModel
            {
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                CredentialNumber = user.CredentialNumber,
                Roles = user.Roles,
                Permissions = user.Permissions
            };
            var userData = new JavaScriptSerializer().Serialize(serializeModel);
            var authTicket = new FormsAuthenticationTicket(1, user.CredentialNumber, DateTime.Now, DateTime.Now.AddMinutes(FormsAuthentication.Timeout.Minutes), false, userData, FormsAuthentication.FormsCookiePath);
            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                HttpOnly = true,
                Secure = true
            };
            if (Request.IsLocal)
            {
                cookie.Secure = false;
            }
            Response.Cookies.Add(cookie);
        }

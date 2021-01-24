     public static ClientContext GetClientContext(string url)
        {
            SecureString securePassword = new SecureString();
            ClientContext context = null;
            try
            {
                using (context = new ClientContext(url))
                {
                    foreach (char c in "Password") securePassword.AppendChar(c);
                    context.Credentials = new SharePointOnlineCredentials("user@tenent.onmicrosoft.com", securePassword);
                    context.Load(context.Web, w => w.ServerRelativeUrl, w => w.Url);
                    context.ExecuteQuery();
                }
            }
            catch (Exception ex)
            {
            }
            return context;
        }

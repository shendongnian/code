     using (ClientContext clientcontext = new ClientContext("http://mysite/"))
        {
            var credentials = new NetworkCredential(domain\UserName, password);
            clientcontext.Credentials = credentials;
            Web web = clientcontext.Web;
            clientcontext.Load(web);
            clientcontext.ExecuteQuery();
        }

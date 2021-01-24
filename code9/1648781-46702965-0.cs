    using (ClientContext context = new ClientContext("sharepoint url"))
      {
          // Use default authentication mode  
            context.AuthenticationMode = ClientAuthenticationMode.Default;
    
          // Specify the credentials for the account that will execute the request  
          var secureString = new SecureString();
          foreach (char c in "password")
          {
               secureString.AppendChar(c);
          }
          context.Credentials = new SharePointOnlineCredentials("username@domain", secureString); //example username :tom@tomtest.com
          ListCollection collList = context.Web.Lists;
          context.Load(collList);
          context.ExecuteQuery();
          foreach (var oList in collList)
          {
              Console.WriteLine("Title: {0}", oList.Title);
          }
          Console.WriteLine("Azure Web Job: Successfully completed.");
        }
     

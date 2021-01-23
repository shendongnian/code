    using (ClientContext ctx = new ClientContext("https://mydomain.sharepoint.com/sites/blsmtekn/dyncrm/"))
    {   
        string userName = "username";
        string password = "password";
    
        SecureString secureString = new SecureString();
        password.ToList().ForEach(secureString.AppendChar);
    
        ctx.Credentials = new SharePointOnlineCredentials(userName, secureString);
    
        List list = ctx.Web.Lists.GetByTitle("Shared Documents");
        CamlQuery caml = new CamlQuery();
        caml.ViewXml = @"<View Scope='Recursive'>
                            <Query>
                            </Query>
                        </View>";
        ListItemCollection listItems = list.GetItems(caml);
        ctx.Load(listItems);
        ctx.ExecuteQuery();
    }

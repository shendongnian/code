    string siteUrl = @"https://sharesss.xyz.net/sites/xxx-xxx/training";
                    System.Net.NetworkCredential cred = new System.Net.NetworkCredential("username", "password", "Domainname");
                    ClientContext clientContext = new ClientContext(siteUrl);
    
                    Web web = clientContext.Web;
    
                    clientContext.Credentials = cred;
    SharePointOnlineCredentials(  (username).ToString(), FetchPasswordFromConsole());
                    List oList = clientContext.Web.Lists.GetByTitle("Name Of List");
                    CamlQuery camlQuery = new CamlQuery();
                    camlQuery.ViewXml = "<View><Query><Where><Geq><FieldRef Name='ID'/>" +
                                        "<Value Type='Number'>10</Value></Geq></Where></Query><RowLimit>100</RowLimit></View>";
                    ListItemCollection collListItem = oList.GetItems(camlQuery);
                    clientContext.Load(web.Lists);
                    clientContext.Load(oList);
                    clientContext.Load(collListItem);
                    clientContext.ExecuteQuery();

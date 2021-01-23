                string siteUrl = "http://MyServer/sites/MySiteCollection";
    
                ClientContext clientContext = new ClientContext(siteUrl);
                SP.List oList = clientContext.Web.Lists.GetByTitle("Announcements");
    
                CamlQuery camlQuery = new CamlQuery();
                camlQuery.ViewXml = "<View><Query><Where><Geq><FieldRef Name='ID'/>" +
                    "<Value Type='Number'>10</Value></Geq></Where></Query><RowLimit>100</RowLimit></View>";
                ListItemCollection collListItem = oList.GetItems(camlQuery);
    
                clientContext.Load(collListItem);
    
                clientContext.ExecuteQuery();
    
                foreach (ListItem oListItem in collListItem)
                {
                    Console.WriteLine("ID: {0} \nTitle: {1} \nBody: {2}", oListItem.Id, oListItem["Title"], oListItem["Body"]);
                }

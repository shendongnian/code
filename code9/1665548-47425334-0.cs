                //File Delete
                Web web = client.Web;
                List list = web.Lists.GetByTitle("Documents");
                client.Load(list);  --> here you will get reference to the list
    
                Microsoft.SharePoint.Client.File file = web.GetFileByServerRelativeUrl("/Documents/mydoc.txt");
                client.Load(file);
                file.DeleteObject();
                client.ExecuteQuery();              

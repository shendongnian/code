         try
            {
         
             var User = "userName";
             var Password = "password";
             var SiteURL = "http://siteUrl/";
             var domainName = "domain name";
            var xDocument = XDocument.Load(@"C:\MyFile11.xml");        
            string xml = xDocument.ToString();
                   
            var context = new Microsoft.SharePoint.Client.ClientContext(SiteURL);
            context.Credentials =   new NetworkCredential(User, GetSecurePassword(Password),domainName);
           
            var searchConfigurationPortability = new Microsoft.SharePoint.Client.Search.Portability.SearchConfigurationPortability(context);
            var Search = new Microsoft.SharePoint.Client.Search.Portability.SearchConfigurationPortability(context);
            var Owner = new Microsoft.SharePoint.Client.Search.Administration.SearchObjectOwner(context, SearchObjectLevel.Ssa);
            //Export search conf schema
            var SearchConfig = Search.ExportSearchConfiguration(Owner);
            context.ExecuteQuery();
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(SearchConfig.Value);
            xdoc.Save("myfilenameSSA.xml");
            // import search conf schema
            Search.ImportSearchConfiguration(Owner, xml);
            context.ExecuteQuery();
      
            }           
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

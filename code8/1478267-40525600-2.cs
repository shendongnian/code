            var forest = Forest.GetCurrentForest();
            var globalCatalog = GlobalCatalog.FindOne(new DirectoryContext(DirectoryContextType.Forest, forest.Name));
            using (var connection = new LdapConnection(new LdapDirectoryIdentifier(globalCatalog.Name, 3268)))
            {
                var entries = new List<SearchResultEntry>();
                var searchRequest = new SearchRequest(string.Empty, "(samaccountname=administrator)", SearchScope.Subtree, null);
                var searchOptionsControl = new SearchOptionsControl(System.DirectoryServices.Protocols.SearchOption.DomainScope);
                searchRequest.Controls.Add(searchOptionsControl);
                var pageResultRequestControl = new PageResultRequestControl(1000);
                searchRequest.Controls.Add(pageResultRequestControl);
                do
                {
                    var response = (SearchResponse)connection.SendRequest(searchRequest);
                    if (response != null)
                    {
                        if (response.ResultCode != ResultCode.Success)
                        {
                            throw new ActiveDirectoryOperationException(response.ErrorMessage, (int) response.ResultCode);
                        }
                        foreach (var c in response.Controls.OfType<PageResultResponseControl>())
                        {
                            pageResultRequestControl.Cookie = c.Cookie;
                            break;
                        }
                        entries.AddRange(response.Entries.Cast<SearchResultEntry>());
                    }
                }
                while (pageResultRequestControl.Cookie != null && pageResultRequestControl.Cookie.Length > 0);
            }

    var domain = httpContextAccessor.HttpContext.User.Identity.Name.Split('\\').First();
    var accountName = httpContextAccessor.HttpContext.User.Identity.Name.Split('\\').Last();
    using (var entry = new DirectoryEntry($"LDAP://{domain}"))
    {
        using (var searcher = new DirectorySearcher(entry))
        {
            searcher.Filter = $"(sAMAccountName={name})";
            searcher.PropertiesToLoad.Add("displayName");
            var searchResult = searcher.FindOne();
            if (searchResult != null && searchResult.Properties.Contains("displayName"))
            {
                var displayName = searchResult.Properties["displayName"][0];
            }
            else
            {
                // user not found
            }
        }
    }

    public static bool GetAdUser(string userLoginID, out string userFirstName,
            out string userLastName, out string userEmailAddress)
    {
        bool foundUser = false;
        userFirstName = null;
        userLastName = null;
        userEmailAddress = null;
        DirectoryEntry activeDirectory = new DirectoryEntry("LDAP://MyDomainName.local", null, null, 
            AuthenticationTypes.ReadonlyServer);  // supply username and password parameters if needed
        try
        {
            DirectorySearcher adSearcher = new DirectorySearcher(activeDirectory);
            adSearcher.SearchScope = SearchScope.Subtree;
            adSearcher.Filter = string.Format("(&(objectCategory=user)(|(SAMAccountName={0})))", userLoginID);
            string[] adPropertyNames =
            {
                "sn",
                "givenname",
                "mail"
                // add more AD attributes to retrieve here as needed
            };
            foreach (string propertyName in adPropertyNames)
                adSearcher.PropertiesToLoad.Add(propertyName);
            SearchResultCollection userSearchResult = adSearcher.FindAll();
            if (userSearchResult != null)
            {
                foreach (SearchResult adAccount in userSearchResult)
                {
                    foundUser = true;
                    ResultPropertyCollection accountProperties = adAccount.Properties;
                    if (accountProperties != null)
                    {
                        userFirstName = GetAdAccountPropertyValue(accountProperties, "givenname");
                        userLastName = GetAdAccountPropertyValue(accountProperties, "sn");
                        userEmailAddress = GetAdAccountPropertyValue(accountProperties, "mail");
                        // add more here as needed
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // log something
        }
        return foundUser;
    }
    private static string GetAdAccountPropertyValue(ResultPropertyCollection adAccountProperties, string propertyName)
    {
        string result = null;
        ResultPropertyValueCollection adAccountPropertyValues = adAccountProperties[propertyName];
        if (adAccountPropertyValues != null)
        {
            result = String.Empty;  // property is valid at this point, so initialize its value to empty to show this
            if (adAccountPropertyValues.Count > 0)
            {
                object adAccountPropertyValue = adAccountPropertyValues[0];
                result = adAccountPropertyValue.ToString();
            }
        }
        return result;
    }

    private static DomainController GetDomainController(string domainpath)
    {
        var domainContext = new DirectoryContext(DirectoryContextType.Domain, domainpath);
        var domain = Domain.GetDomain(domainContext);
        var controller = domain.FindDomainController();
        return controller;
    }
    
    private static MyMethod()
    {
        var domainController = GetDomainController(ActiveDirectorySettings.DomainPath);
    
        // Lookup the information in AD
        var ldapEntry = new DirectoryEntry(string.Format("LDAP://{0}", domainController)) { AuthenticationType = AuthenticationTypes.Secure | AuthenticationTypes.FastBind };
        DirectorySearcher ds;
    
        ds = new DirectorySearcher(ldapEntry)
        {
            SearchScope = SearchScope.Subtree,
            Filter = "(&" + "(objectClass=user)" + "(department=" + departmentname + "*))"
        };
    
        ds.PropertiesToLoad.Add("department");
        if (ds.FindAll().Count >= 1)
        {
            // getting list of all departments from the database
    	    var departmentsList = AllDepartments();
    	
    	    // getting list of all departments from active directory
    	    var results = ds.FindAll();
    
    	    // filtering distinct departments from the result
    	    var uniqueSearchResults = results.Cast<SearchResult>().Select(x => GetProperty(x,"department")).Distinct();
            
            // here firstly i am getting the department list from the database and checking it for null, then using linq query i am comparing the result with ad department results
    	    if (departmentsList != null)
    	    {
        		addUsersList.AddRange(from sResultSet in uniqueSearchResults
        		where !departmentsList.Exists(u => u.UserDepartment == sResultSet)
        		select new UsersAndDepartments
        		{
            		UserDepartment = sResultSet
        		});
    	    }
    	    else
    	    {
        		addUsersList.AddRange(uniqueSearchResults.Select(departmentName => new UsersAndDepartments
        		{
    		        UserDepartment = departmentName
    		    }));
    	    }
        }
    }

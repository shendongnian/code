    var listOfDirectReportsNames = // Get the list of all the directreports user names and store in list- List<string>();
    
    var pc = new System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, Environment.UserDomainName);
    foreach (string name in listOfDirectReportsNames)
    {
    	var up = new System.DirectoryServices.AccountManagement.UserPrincipal(pc);
    	up.Name = name; //to test this, pass the exact LDAP Name/DisplayName/GivenName of any user
    	System.DirectoryServices.AccountManagement.PrincipalSearcher searcher = new System.DirectoryServices.AccountManagement.PrincipalSearcher(up);
    	var res = searcher.FindOne();
    	string empID = ((System.DirectoryServices.AccountManagement.UserPrincipal)res).EmployeeId;//here you will get employee ID
    	up.Dispose();
    }

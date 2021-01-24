    $Source = @"
    // " "  <-- this just makes the code highlighter work
    // Syntax:  [soexample.search]::Get("LDAP Path", "property1", "property2", "etc...")
    // Example: [soexample.search]::Get("LDAP://CN=Users,DC=mydomain,DC=com","givenname","sn","samaccountname","distinguishedname")
    
    namespace soexample
    {
    	using System;
    	using System.DirectoryServices;
    
    	public static class search
    	{
    		public static string Get(string ldapPath, params string[] propertiesToLoad)
    		{
    			DirectoryEntry entry = new DirectoryEntry(ldapPath);
    			DirectorySearcher searcher = new DirectorySearcher(entry);
    			searcher.SearchScope = SearchScope.OneLevel;
    			foreach (string p in propertiesToLoad) { searcher.PropertiesToLoad.Add(p); }
    			searcher.PageSize = 100;
    			searcher.SearchRoot = entry;
    			searcher.CacheResults = true;
    			searcher.Filter = "(sAMAccountType=805306368)";
    			SearchResultCollection results = searcher.FindAll();
    
    			foreach (SearchResult result in results)
    			{
    				foreach (string propertyName in propertiesToLoad)
    				{
    					foreach (object propertyValue in result.Properties[propertyName])
    					{
    						Console.WriteLine(string.Format("{0} : {1}", propertyName, propertyValue));
    					}
    				}
    				Console.WriteLine("");
    
    			}
    			return "";
    		}
    	}
    }
    "@
    $Asem = ('System.DirectoryServices','System')
    Add-Type -TypeDefinition $Source -Language CSharp -ReferencedAssemblies $Asem

    void Main()
    {
        ClientContext context = new ClientContext("https://sharepoint.oshirowanen.com/sites/oshirodev/");
    	context.Credentials = new NetworkCredential("user", "pass", "oshirowanen.com");
    	Principal user = context.Web.EnsureUser(@"oshirowanen\tom");
    	ChangeItemPermissions(context, "/sites/oshirodev/Library1/Folder1/File1.docx", "Library1", user, RoleType.Reader);
    }
    
    // Define other methods and classes here
    public static ListItem LoadItemByUrl(List list, string url)
    {
    	var context = list.Context;
    	string ext = System.IO.Path.GetExtension(url);
    	
    	var query = new CamlQuery();
    	if (string.IsNullOrEmpty(ext))
    	    query.ViewXml = String.Format("<View><RowLimit>1</RowLimit><Query><Where><Eq><FieldRef Name='FileRef'/><Value> Type='Url'>{0}</Value></Eq></Where></Query></View>", url);
    	else
        {
    		query.ViewXml = String.Format("<View><ViewFields><FieldRef Name=\"FileLeafRef\" /></ViewFields><Query><Where><Eq><FieldRef Name=\"FileLeafRef\" /><Value Type=\"Text\">{0}</Value></Eq></Where></Query><RowLimit>1</RowLimit></View>", System.IO.Path.GetFileName(url));
            query.FolderServerRelativeUrl = System.IO.Path.GetDirectoryName(url).Replace("\\", "/");
        }
    	
    	var items = list.GetItems(query);
    	context.Load(items);
    	context.ExecuteQuery();
    	return items.Count > 0 ? items[0] : null;
    }
    
    public void ChangeItemPermissions(ClientContext context, string url, string listName, Principal user, RoleType type)
    {    
    	var list = context.Web.Lists.GetByTitle(listName);
    	var item = LoadItemByUrl(list, url);
    	var roleDefinition = context.Site.RootWeb.RoleDefinitions.GetByType(type);
    	var roleBindings = new RoleDefinitionBindingCollection(context) { roleDefinition };
    	item.BreakRoleInheritance(false, true);
    	item.RoleAssignments.Add(user, roleBindings);
    	context.ExecuteQuery();
    }

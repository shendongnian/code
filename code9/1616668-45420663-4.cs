    string url = "http://sharepointsite/";
    var context = new ClientContext(url);    
    var camlQuery = CamlQuery.CreateAllFoldersQuery();
    var list = context.Web.Lists.GetByTitle("Tasks");
    var items = list.GetItems(camlQuery);
    context.Load(items);
    context.ExecuteQuery();

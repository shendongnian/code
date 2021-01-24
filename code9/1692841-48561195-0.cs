    List templateList = web.Lists.GetByTitle(libraryName);
    clientContext.Load(templateList);
    clientContext.ExecuteQuery();
    
    ListItemCollection templateListItems = templateList.GetItems(CamlQuery.CreateAllItemsQuery());
    clientContext.Load(templateListItems);
    clientContext.ExecuteQuery();

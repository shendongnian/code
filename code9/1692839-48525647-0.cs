    var docs = clientContext.Web.Lists.GetByTitle(Library);
    var listItem = docs.GetItemById(listItemId);
    clientContext.Load(docs);
    clientContext.Load(listItem, i => i.File);
    clientContext.ExecuteQuery();
    var fileRef = listItem.File.ServerRelativeUrl;

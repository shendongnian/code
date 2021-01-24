    using (ClientContext ctx = new ClientContext(url))
    {
        Web web = ctx.Web;
        List list = web.Lists.GetById(listId);
        ListItem item = list.GetItemById(itemId);
        ctx.Load(item);
        ctx.ExecuteQuery();
        FieldUrlValue fieldValue = (FieldUrlValue)item["Bild"]; //<-- casting!
        string bildUrl = fieldValue.Url; //<-- here you can access the values
    }

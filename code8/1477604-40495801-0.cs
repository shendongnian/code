    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Events;
    public void OnItemDeleted(object sender, EventArgs args)
    {
        Item item = Event.ExtractParameter(args, 0) as Item;
        ID parentId = Event.ExtractParameter(args, 1) as ID;
        Item itemParent = item.Database.GetItem(parentId);
        if (itemParent != null)
        {
            // Do stuff
        }
    }

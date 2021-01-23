    public override void ItemAdded(SPItemEventProperties properties)
    {
        properties.ListItem["Patient Name"] = "Scott Brown";
        properties.ListItem.Update();
        base.ItemAdded(properties);
    }

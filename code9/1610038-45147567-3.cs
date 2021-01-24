    protected void CreateNewEntry(Object sender, EventArgs e)
    {
        var entryFlags = Session["UserEntryFlags"] as UserEntryFlags;
        if (entryFlags == null) entryFlags = new UserEntryFlags();
        entryFlags[EntryEventType.NewEntry] = EntryEvent.GetTrue(EntryEventType.NewEntry);
        Session["UserEntryFlags"] = entryFlags;
    }
    protected void DeleteNewEntry(Object sender, EventArgs e)
    {
        var entryFlags = Session["UserEntryFlags"] as UserEntryFlags;
        if (entryFlags == null) entryFlags = new UserEntryFlags();
        entryFlags[EntryEventType.DeletedEntry] = EntryEvent.GetTrue(EntryEventType.DeletedEntry);
        Session["UserEntryFlags"] = entryFlags;
    }

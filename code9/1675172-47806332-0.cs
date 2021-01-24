    public List<ListItem> GetAllListItems()
    {
        return syncconn.Table<ListItem>()
                       Where.(c => c.Table) // Where table == True
                       .ToList()
    }

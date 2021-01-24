    public List<ListItem> GetList()
    {
        // get "db" here.
        return db.tbl_patnici.Select(x => new ListItem {
            ID = x.pID,
            Text = x.firstname + " " + x.lastname
        });
    }

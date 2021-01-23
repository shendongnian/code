    public IEnumerable<ListItem> AllTextEntries {
        get
        {
            var items = new List<ListItem>();
            using(var context=new DBContext()){
                 foreach(var item in context.listTable.ToList()){
                      items.Add(new ListItem(){Id=item.Id,Name=item.Name});
                 }
            }
            return items;
        }
    }

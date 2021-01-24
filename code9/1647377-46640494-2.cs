    foreach(DataRow row in gldt.Rows){
        var item = new Item();
        item.Name = row["Name"].ToString();
        item.Type = row["Type"].ToString();
        ...
        AllAdapters.Value.Add(item);
    }

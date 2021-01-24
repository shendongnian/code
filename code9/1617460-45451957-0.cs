    public static SelectList ToSelectList(List<YourInterface> addlist)
    {
        addlist.Insert(0, new YourDerived { Id = -1, Name = "SELECT" });
        var list = new SelectList(addlist, "Id", "Name");
        return list;    
    }

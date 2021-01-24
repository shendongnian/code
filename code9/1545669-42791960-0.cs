    List<string> valueList = new List<string>();
    using (var ctx = new DataEntities1())
    {
        var query = ctx.myTable.Where(x => x.pcds == scode).SingleOrDefault();
    
        foreach (var item in columnsArray)
        {
            valueList.Add(typeof(myTable).GetProperty(onsColumns[Convert.ToInt32(item)]).GetValue(query).ToString());
        }
    }

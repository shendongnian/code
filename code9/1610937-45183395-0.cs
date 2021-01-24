    var NameCollection = dt2.AsEnumerable().Select(x=> x.Field<string>("Name")).ToList();
    
    merge = dt1.AsEnumerable()
               .Where(r => NameCollection.Contains(r.Field<string>("Name")))
               .CopyToDataTable();

    //This creates a "strongly" typed list, instead of List<object>:
    var list = new[] { (new { Number = 500 }) }.ToList();
    DataTable table = new DataTable();
    using (var reader = ObjectReader.Create(list))
    {
        table.Load(reader);
    }

    List<object> list = new List<object> { new { Number = 500 } };
    DataTable table = new DataTable();
    // Note that type information is derived directly from the first object in the list, 
    // so try not to pass an empty one :)
    using (var reader = new ObjectReader(list[0].GetType(), list, null))
    {
        table.Load(reader);
    }

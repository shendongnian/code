    while (reader.Read())
    {
        results.Add(new MyProduct() {
            ProductID = reader.GetInt32(oProductID),
            ProductName = reader.GetString(oProductName, "(No name)"),
            MinReorder = reader.GetInt32(oReorder, null)
            .....
        });
    }

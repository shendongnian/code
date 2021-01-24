    using (SqlDataReader reader = command.ExecuteReader())
    {
        //pull the entire table to an in-memory list.  
        var items = db.Items.ToList();
        while (reader.Read())
        {
            Item item = items.Where(x => x.OtherItem_Id == (int)reader["Id"]).FirstOrDefault();
            prop1 = item.prop1;
            prop2 = item.prop2;
            prop3 = item.prop3;
        }
    }

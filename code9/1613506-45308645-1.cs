    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            Item item = db.Items.AsNoTracking().Where(x => x.OtherItem_Id == (int)reader["Id"]).FirstOrDefault();
    
            prop1 = item.prop1;
            prop2 = item.prop2;
            prop3 = item.prop3;
        }
    }

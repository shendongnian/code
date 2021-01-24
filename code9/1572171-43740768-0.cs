    MySqlCommand command = new MySqlCommand("getCategory", myConnexion);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    using(var cursor = command.ExecuteReader())
    {
        while (cursor.Read())
        {
            int id = Convert.ToInt32(cursor["id"]);
            string categoryName = Convert.ToString(cursor["name"]);
            Category category = new Category(id, categoryName);
            database.addCategory(category);
        }
    }

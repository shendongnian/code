    IEnumerable<Component> SelectComponents()
    {
        using (IDbConnection connection = OpenConnection())
        {
            const string query = @"SELECT p.ID, p.Component as ComponentX, 
                                          p.Color_ID, p.Material_ID, 
                                          c.Color, m.Material 
                                    FROM Component p 
                                    JOIN Color c on p.Color_ID = c.ID 
                                    JOIN Material m on p.Material_ID = m.ID";
            return connection.Query<Component>(query, null);
        }
    }

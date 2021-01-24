    using (var con = new SqlConnection("..."))
    using (var cmd = new SqlCommand("SELECT * FROM guitarItems WHERE brand LIKE @brand", con))
    {
        cmd.Parameters.AddWithValue("@brand", itemCategory);`
        
        con.Open();
        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                ...
                
                yield return new GuitarItems(id, ...);
            }
        }
    }
}

    // Create a SQL command to execute the sproc
    var cmd = db.Database.Connection.CreateCommand(); // db is your data context
    cmd.CommandText = "[dbo].[get_values]";
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("@Id2", id); // if you have parameters.
    
    db.Database.Connection.Open();
    var reader = cmd.ExecuteReader();
    // Read Table2 from the first result set
    var table2 = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<Table2Model>(reader, "table2", MergeOption.AppendOnly);   
    // Move to second result set and read @temp
    reader.NextResult();
    var temp = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<TempModel>(reader, "temp", MergeOption.AppendOnly); 
    // I forgot if you need to use @temp or temp only

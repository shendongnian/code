    //....
    using (var conn = new SqlConnection(connStr))
    {
      await conn.OpenAsync();
      SqlCommand cmd = new SqlCommand(sql, conn);
      try
      {
        using ( var rdr = await cmd.ExecuteReaderAsync())
        { 
          while (await rdr.ReadAsync())
          {
            // do simple processing here
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }
    //...

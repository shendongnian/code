    var dataTable = new DataTable();
    var sql = @"
      SELECT TOP 1
      FROM KeyValuationActual_destination
      WHERE [SystemType] = @system
      ";
    using (var conn = new SqlConnection(_connection))
    {
      conn.Open();
      using (var da = new SqlDataAdapter(sql, conn))
      {
        // blah blah blah
        da.Fill(dataTable);
      }
    }
    // "using" statements avoid the need to manually Close(), Dispose(), etc.

    using (var con = new SqlConnection(GlobalSettings.connection))
    {
      con.Open();
      using (var cmd = new SqlCommand() { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "p_ValRefNumber" })
      {
        /* Assuming both parameters are integers.
           Change SqlDbType if necessary. */
        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@DocumentNumber", SqlDbType = SqlDbType.Int, Value = Docnumber });
        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SupplierID", SqlDbType = SqlDbType.Int, Value = SupplierID });
        
        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        {
          return dr.Read() && (Convert.ToInt32(dr["Status"]) == 1)
        }
      }
    }

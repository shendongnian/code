    bool unset = true;
    using (var command = new SqlCommand()) {
      command.CommandText = "sp_set_session_context";
      command.CommandType = CommandType.StoredProcedure;
      command.Parameters.Add("@key", SqlDbType.NVarChar, 128);
      command.Parameters.Add("@value", SqlDbType.Variant, -1);
      for (int cycles = 0; cycles != 10; ++cycles) { 
        ++cycles;
        using (var connection = 
          new SqlConnection(@"Data Source=.\sqlserver2016;Integrated Security=SSPI")
        ) {
          connection.Open();
          // Set as many values as we can
          int keys = 0;
          while (true) {
            command.Connection = connection;
            command.Parameters["@key"].Value = keys.ToString();
            command.Parameters["@value"].Value = new String(' ', 8000);
            try {
              command.ExecuteNonQuery();
              ++keys;
            } catch (SqlException e) {
              Console.WriteLine("Failed setting at {0}: {1}", keys, e.Message);
              break;
            }
          }
          if (unset) {
            // Now unset them
            for (; keys >= 0; --keys) {
              command.Connection = connection;
              command.Parameters["@key"].Value = keys.ToString();
              command.Parameters["@value"].Value = DBNull.Value;
              try {
                command.ExecuteNonQuery();
              } catch (SqlException e) {
                Console.WriteLine("Failed unsetting at {0}: {1}", keys, e.Message);
                break;
              }
            }
          }
        }
      }
    }
    

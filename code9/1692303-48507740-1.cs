     sql_cmd = sql_conn.CreateCommand();
     sql_cmd.CommandText = "SELECT * FROM temp where id=12";
     string newValue = String.Empty;
     try {
          sql_conn.Open();
          sql_reader = sql_cmd.ExecuteReader();
          while (sql_reader.Read()) {
               newValue = sql_reader["Temp1"].ToString();  // store in local variable
          }
     } catch (Exception e) {
          MessageBox.Show(e.Message);
     } finally {
          sql_conn.Close();  // SqlConnection.Close should be in finally block
     }
     UpdateLabels(newValue);

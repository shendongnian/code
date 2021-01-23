      using (OleDbCommand command = conn.CreateCommand())
      {
           // create command with placeholders
           cmd.CommandText = 
              "SELECT * FROM [StokLembar$] WHERE [Limit] = @limit ";
           // add named parameters
           command.Parameters.AddRange(new OleDbParameter[]
           {
               new OleDbParameter("@limit", row.Cells["Limit"].Value.ToString())
           });
           // execute
           command.ExecuteNonQuery();
      }

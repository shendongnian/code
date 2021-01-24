     // Extract method: do not cram everything into single IndexChanged  
     private void CoreAddOptions() {
       // Do not open a global connection
       // Wrap IDisposable into using 
       using (SqlConnection conn = new SqlConnection(ConnectionString)) { 
         conn.Open(); 
         // Make Sql Readable
         // Make Sql paramterized  
         string sql = 
           @"select Options,
                    OptionsID
               from tOptions
              where Id = @prm_Id"; 
         // Wrap IDisposable into using
         using (SqlCommand comm = new SqlCommand(sql, conn)) {
           // Do not hardcode SQL but use parameters
           comm.Parameters.AddWithValue("@prm_Id", ddlModel.SelectedValue);
           // Wrap IDisposable into using
           using (var reader = comm.ExecuteReader()) {
             while (reader.Read()) {
               // Use Convert instead of Get + ToString
               var optionsItem = new ListItem(
                 Convert.ToString(reader[0]),
                 Convert.ToString(reader[1]));
               lbxOptions.Items.Add(optionsItem); 
             }
           }
         }
       }
     } 

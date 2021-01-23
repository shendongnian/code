    string connectionString = ... //web|app.config
    using (SqlConnection sqlconn = new SqlConnection(connectionString)){
       using(SqlCommand com = new SqlCommand("sp_ToolTipLookup", sqlconn)){
           com.CommandType = System.Data.CommandType.StoredProcedure 
           sqlconn.Open();
           using (SqlDataReader data = com.ExecuteReader()){ //Call the SP
               int i = 0;
               while(data.Read()) {
                   rptgrid.VisibleColumns[i].ToolTip = data["ToolTip"].ToString(); 
                  i++;
               }
           }
       }
    }

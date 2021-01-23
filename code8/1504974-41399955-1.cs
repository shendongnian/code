    string connectionString = ... //web|app.config
    using (SqlConnection sqlconn = new SqlConnection(connectionString)){
       using(SqlCommand com = new SqlCommand("sp_ToolTipLookup", sqlconn)){
           com.CommandType = System.Data.CommandType.StoredProcedure 
           sqlconn.Open();
           using (SqlDataReader data = com.ExecuteReader()){ //Call the SP
               while(data.Read()) {
                   foreach(var col in rptgrid.VisibleColumns){
                       if (col.Name == data["FieldName"].ToString()){
                           rptgrid.VisibleColumns[col.Index].ToolTip = data["ToolTip"].ToString();
                       }
                   }
               }
           }
       }
    }

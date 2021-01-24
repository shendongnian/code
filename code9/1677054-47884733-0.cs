    protected void Button1_Click(object sender, EventArgs e)  
    {  
        try  
        {  
            string cs = ConfigurationManager.ConnectionStrings["SchoolConnectionString"].ConnectionString;  
            using (SqlConnection sqlConn = new SqlConnection(cs))  
            {  
                DataSet ds = aSH_ORDER_DBDataSet1;  
                DataTable dtStudentMaster = ds.Tables["Student"]; 
                //  ds.Tables["Student"], if aSH_ORDER_DBDataSet1 has multiple tables in it specify the table name else ds.Tables[0] is fine
                sqlConn.Open();  
                using (SqlBulkCopy sqlbc = new SqlBulkCopy(sqlConn))  
                {  
                    sqlbc.DestinationTableName = "StudentMaster"; 
                    // StudentMaster - Table need to be updated in SQLServer
                    // Make sure you have the similar column names and datatype in both datatable and sql server table
                    sqlbc.ColumnMappings.Add("Name", "Name");  
                    sqlbc.ColumnMappings.Add("Phone", "Phone");  
                    sqlbc.ColumnMappings.Add("Address", "Address");  
                    sqlbc.ColumnMappings.Add("Class", "Class");  
                    sqlbc.WriteToServer(dtStudentMaster);  
                    Response.Write("Bulk data stored successfully");  
                }  
            }  
        }  
        catch (Exception ex)  
        {  
            throw ex;  
        }  
    }  

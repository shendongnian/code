    DataTable myTable= new DataTable();
    using (var con = new SqlConnection(AConnectionString))
    using (SqlCommand cmd = new SqlCommand("STORED_PROCEDURE", con)) 
    using (var da = new SqlDataAdapter(cmd))
    {
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //Data adapter(da) fills the data retuned from stored procedure 
       //into myTable
        da.Fill(myTable);
    }

    int statusCode = -1;
    if(keyword.ToLower() == "booked")
       statusCode = 1;
    else if(keyword.ToLower() == "Pending")
       statusCode = 0;
    string querySql = " SELECT * FROM View_Booking" +
                      " WHERE CAST(bkID AS NVARCHAR(MAX)) LIKE @bkID" + 
                      " OR bkSlot LIKE @keyword" +
                      " OR bkStatus = @status";
    using (SqlConnection dbConn = new SqlConnection("connectionString here"))
    {
        dbConn.Open();
        using (SqlCommand sqlCommand = new SqlCommand(querySql, dbConn))
        {
            sqlCommand.Parameters.Add("@bkID", SqlDbType.VarChar).value ="%" + keyword + "%";
            sqlCommand.Parameters.Add("@bkSlot", SqlDbType.VarChar).value ="%" + keyword + "%";
            sqlCommand.Parameters.Add("@status", SqlDbType.int).value = statusCode;
            sqlCommand.ExecuteNonQuery();
         }
    }

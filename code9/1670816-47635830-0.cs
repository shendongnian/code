    try {
        dbconnection.Open();
    
        SqlDataReader myReader = null;
    
        SqlCommand cmd = new SqlCommand(
            "SELECT SUM(AMOUNT) AS FinalAmount FROM [ordersTable] WHERE orderNo = @orderNo ", 
            con
        );
        cmd.Parameters.Add(new SqlParameter("@orderNo", orderNo ));
           
        myReader = cmd.ExecuteReader();
        while (myReader.Read()) {
            Session["FinalAmount"]= (myReader["FinalAmount"]);
        } 
        dbconnection.Close();
    }
    catch (Exception ex) {
        _logger.Error(ex);
    }

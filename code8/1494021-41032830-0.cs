    string strQuery = "INSERT INTO [Order] (Quantity, Type, DateTime)Values( @qty,@type,@date)";
    // create and open connection here 
    using (SqlCommand cmdSQL = new SqlCommand(strQuery))
    {
        // assign connection for this comnmand
        cmdSQL.Parameters.Add("@qty", SqlDbType.Int).Value = qty;
        cmdSQL.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
        cmdSQL.Parameters.Add("@date", SqlDbType.DateTime).Value = dtstmp;
        cmdSQL.ExecuteNonQuery();
    }

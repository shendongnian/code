    using (SqlDataReader reader = command.ExecuteReader())
    {
    	while(reader.Read())
    	{
    	   // String OrderCustommerName = reader.GetString(3).TrimEnd();
    	   // String OrderCustommerCity= reader.GetString(4).TrimEnd();
    	   // lbOrderData.Text = OrderCustommerName + " " + OrderCustommerCity;
    	}
    }

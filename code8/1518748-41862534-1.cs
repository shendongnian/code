    try{
    	TSTTWI.Open();
    
    	nc.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
    	nc.Parameters.AddWithValue("@Operator", txtName.Text);
    	....
    
    	nc.ExecuteNonQuery();
    	TSTTWI.Close();
    }
    catch(Exception exception){
    &#xD;     //log the exception somewhere 
    }

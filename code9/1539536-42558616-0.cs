    try
    {
       cnn.Open();
       Response.Write("Connection Made");
    
       string query = "INSERT INTO Customer(Username,Password,Email) VALUES('" + model1.Username + "','" + model1.Password + "','" + model1.Email + "')";
       SqlCommand command = new SqlCommand(query, cnn);
       command.ExecuteNonQuery();
    }
    catch
    {  //break point
       //log
    }
    finally
    {
        cnn.Close();
    }

    MySqlDataReader myReader;
    try
    {
    	conLossDB.Open();
    	for (int i = 0; i < 366; i++)
    	{
    		MySqlCommand cmdLossDB = new MySqlCommand(query, conLossDB);
    		cmdLossDB.Parameters.AddWithValue("@PE", textBox2.Text);
    		cmdLossDB.Parameters.AddWithValue("@Production_Time", forecast[i, 2]);
    		cmdLossDB.Parameters.AddWithValue("@Potential", forecast[i, 3]);
    		cmdLossDB.ExecuteNonQuery();
    	}
    	
    	MessageBox.Show("Forecast Results Saved");
    	
    }
    catch (Exception ex)
    {
    	MessageBox.Show(ex.Message);
    }
     
 
  

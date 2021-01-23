    int rows = 0;
    string message = bf.Deserialize(client).ToString();
    SqlCommand com = new SqlCommand(@"insert into messages 
       (messagetext,sentdate) 
       values 
       (@message, @sent)", sc);
    com.Parameters.Add("@message",SqlDbType.VarChar).Value = message;
    com.Parameters.Add("@sent",SqlDbType.DateTime2).Value=DateTime.Now;
    try
    {	        
    	sc.Open();
    	rows = com.ExecuteNonQuery();
    	sc.Close();
    }
    catch (Exception ex)
    {
    	MessageBox.Show("Something went wrong:"+ex.Message);
    }
    if (rows < 1) // this should never happen without an exception - redundant
    {
    	MessageBox.Show("Something went wrong - no rows were inserted");
    }

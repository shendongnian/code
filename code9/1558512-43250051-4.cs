    try
    {
    	string textt = "SELECT AVG (Total_Divida) FROM t_pagamentos";
        cmd.CommandText = textt;
        connection.Open();
        cmd.Connection = connection;
        cmd.CommandType = CommandType.Text;
    
        decimal average = (decimal)cmd.ExecuteScalar();
        TextBox3.Text = average.ToString();
    }
    catch(Exception ex)
    {
         // log your exception here...
         MessageBox.Show("nothing");
    }
     

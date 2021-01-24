    SqlCommand command = new SqlCommand();
    command.Connection = new SqlConnection("Data Source=.;Initial Catalog=mydb;Integrated Security=SSPI");
    command.Connection.Open();
    
    for (int i = 0; i < ListToUpdate.Count; i = i + 500) {
    	var batchList = ListToUpdate.Skip(i).Take(500);
    	for (int j = 0; j < batchList.Count(); j++) {
    		command.CommandText += string.Format("update mytable set column=@s_id{0} where columnid = @id{0};", j);
    		command.Parameters.AddWithValue("@s_id" + j, batchList[j].QuantitySoldTotal);
    		command.Parameters.AddWithValue("@id" + j, batchList[j].ItemId)
    	}
        command.ExecuteNonQuery();
        command.CommandText = CommandType.Text;
    }
    command.Connection.Close();

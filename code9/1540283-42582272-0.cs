       SqlConnection con1 = new SqlConnection();
       con1.ConnectionString = "Server = (local); Database = My_DataBase; Integrated Security = true";
       con1.Open();
       SqlCommand cm1 = new SqlCommand();
       cm1.Connection = con1;
       cm1.CommandText = "insert into Users values('" + update.Message.Chat.Id.ToString() + "','" + update.Message.Chat.FirstName + "','" + update.Message.Chat.LastName + "','@" + update.Message.Chat.Username + "','" + req1.Status + "'";
       cm1.ExecuteNonQuery();
       con1.Close();

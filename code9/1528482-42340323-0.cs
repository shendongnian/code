     var Related_Huge_Table_Data = "TABLENAME";//Input table name here
     var Id = "ID"; //Input Id name here     
     var connectionString = "user id=USERNAME; password=PASSWORD server=SERVERNAME; Trusted_Connection=YESORNO; database=DATABASE; connection timeout=30";
     SqlCommand sCommand = new SqlCommand();
     sCommand.Connection = new SqlConnection(connectionString);
     sCommand.CommandType = CommandType.Text;
     sCommand.CommandText = $"COUNT(*) FROM {Related_Huge_Table_Name} WHERE Id={ID}";
     sCommand.Connection.Open();
     SqlDataReader reader = sCommand.ExecuteReader();
     var count = 0;
     if (reader.HasRows)
     {
         reader.Read();
         count = reader.GetInt32(0);
     }
     else
     {
          Debug.WriteLine("Related_Huge_Table_Data: No Rows returned in Query.");
     }
     sCommand.Connection.Close();

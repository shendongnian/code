     DataTable temp = new DataTable();
     adapter = new MySqlDataAdapter(command);
     adapter.Fill(temp);
     foreach(DataColumn column in  temp.Columns) 
     {
         foreach(DataRow row in temp.Rows)
         {
              Console.WriteLine(row[column]);
         }
     }

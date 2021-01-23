     using (SqlConnection Connection = new SqlConnection((@"DataSource"))) {
       using (SqlCommand myCommand = new SqlCommand(sql, Connection)) {
         Connection.Open();
         using (SqlDataReader myReader = myCommand.ExecuteReader()) {
           DataTable dt = new DataTable();
           dt.Load(myReader);
           
           // You can obtain the string[][] array via Linq: 
           string[][] result = dt
             .AsEnumerable()
             .Select(record => new string[] {
                Convert.ToString(record["id"]),
                Convert.ToString(record["Marks"]), })
             .ToArray();
           ...
         }
         ... 

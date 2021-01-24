    using(var dbConnect = new SQLiteConnection("DataSource=school.db;Version=3;"))
    {
       dbConnect.Open();
       using(var transaction = dbConnect.BeginTransaction())
       {
           string insertQuery = ...// your insert query
           using (var cmd = dbConnect.CreateCommand())
           {
              cmd.CommandText = insertQuery;
             foreach (DataRow dr4 in dt4.Rows)
             {
               cmd.Parameters.AddWithValue(...);
             }
             cmd.ExecuteNonQuery()
           }
           transaction.Commit();
       }
    }

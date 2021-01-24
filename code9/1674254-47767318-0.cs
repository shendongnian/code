        private static DataTable GetData()
        {
            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(conf))
            {
                 string query = "SELECT [ID], [Desc], [tID] FROM [table] WHERE [Updated] = 0";
                 try
                 {
                     conn.Open();
                     SqlCommand cmd = new SqlCommand();
                     cmd.CommandText = query;
                     cmd.Connection = conn;
                     SqlDataAdapter da = new SqlDataAdapter(cmd);
                     da.Fill(result);
                     da.Dispose();
                 }
                 catch(Exception e)
                 {
                 }
                 finnaly
                 {
                     conn.Close();
                     conn.Dispose();
                 }
             }
             return result;
         } 

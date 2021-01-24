    using (OleDbConnection con = new OleDbConnection(connectionString))
    {
        try
        {                   
            var dataTable = new DataTable();
            con.Open();
            var tableschema = con.GetSchema("Tables");
            // To get the first sheet name you use the first row and the column named TABLE_NAME
            var firstsheet = tableschema.Rows[0]["TABLE_NAME"].ToString();
            string name_query = "SELECT F1 FROM [" + firstsheet + "] WHERE F1 <> ''";
            OleDbDataAdapter da = new OleDbDataAdapter(name_query, con);
            da.Fill(dataTable);
       }
       catch .....
    }

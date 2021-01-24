    // don't forget this using statements
    using System.Data;
    using System.Data.SqlClient;
    // here's the code.
    var connectionstring = "YOUR_CONN_STRING";
    var table = new DataTable("MyData");
    using (var cn = new SqlConnection(connectionstring))
    {
        cn.Open();
        using (var cmd = cn.CreateCommand())
        {
            cmd.CommandText = "Select [Fields] From [Table] etc etc";
                              // your SQL statement here.
            using (var adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(table);
            } // dispose adapter
        } // dispose cmd
        cn.Close();
    } // dispose cn
    foreach(DataRow row in table.Rows) 
    {
        // do something with the data set.
    }

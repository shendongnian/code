    using Oracle.DataAccess.Client;
      private void Form1_Load(object sender, EventArgs e)
        {
            var select = "SELECT * FROM tblProject";
             conn.ConnectionString = "Data Source=(DESCRIPTION="
             + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.3.50.205)(PORT=1521)))"
             + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=sid)));"
             + "User Id=username;Password=pass;";
    
    
        using (OracleConnection connection = new OracleConnection(conn.ConnectionString))
            {
                connection.Open(); 
                OracleDataAdapter adapter = new OracleDataAdapter(select, connection);
    
                try
                {
                    var ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
    
    
            }
    
    }

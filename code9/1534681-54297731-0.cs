    private void getexpireddate()
    {
    try
    {
    MySqlConnection con = new MySqlConnection(conn);
    connect.Open();
    string sql="SELECT expireddate FROM data1 where date(date) = date(now())";
    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
    DataTable ds = new DataTable();
    da.Fill(ds);
    datagrid.DataSource=ds;
    
    }
    catch(Exception ee)
    {
    Console.WriteLine(ee.Message);
    }
    }

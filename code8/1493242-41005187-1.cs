    List<string> tables = new List<string>()
    { 
      "Abertura Caixa", "Caixa Local", "Cartões Ocorrencias Local",
      "Cartões Pagos Local", ..... all other table names... 
    };
    
    conn = new OleDbConnection("......");
    conn.Open();
    DataSet ds = new DataSet();
    foreach(string table in tables)
    {
        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + table + "]", conn);
        DataTable dt = new DataTable(table);
        dt.Load(cmd.ExecuteReader());
        ds.Tables.Add(dt);
    }

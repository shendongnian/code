    OleDbConnection conn = new OleDbConnection(ConnectionString);
    conn.Open();
    OleDbCommand cmd = new OleDbCommand(query, conn);
    OleDbDataReader reader = cmd.ExecuteReader();
    List<Stock> stockData = new List<Stock>();
    while (reader.Read())
    {
        stockData.Add(new Stock()
        {
            StoreNumber = reader.GetValue(0).ToString(),
            StockCode = reader.GetValue(1).ToString(),
            DesiredQuantity = reader.GetDouble(2)
        });
    }
    reader.Close();

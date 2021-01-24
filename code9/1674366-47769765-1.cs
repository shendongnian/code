    string insertQuery = "INSERT INTO dbo.Stocks_Item (StockDate, StockTime) VALUES(@StockDate, @StockTime);";
    SqlCommand cmdInsert = new SqlCommand(insertQuery, conn);    
    
    // define and set parameters
    cmdInsert.Parameters.Add("@StockDate", SqlDbType.Date).Value = DateTime.Now;
    cmdInsert.Parameters.Add("@StockTime", SqlDbType.Time).Value = DateTime.Now.TimeOfDay;
    conn.Open();
    cmdInsert.ExecuteNonQuery();
    conn.Close();
    MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

    private void drop1_SelectedIndexChanged(object sender, EventArgs e)
            {
                String selI = drop1.SelectedItem.ToString();
                String strConnect = ("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\smith\\Documents\\SqlStockDB.mdf; Integrated Security = True; Connect Timeout = 30");
                SqlConnection Connect = new SqlConnection(strConnect);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = Connect;
                sqlcmd.CommandType = CommandType.Text;
                
                if (selI == "General")
                {
                    sqlcmd.CommandText = "SELECT [Call Sign] AS Call_Sign, [Current Price] AS Current_Price FROM [Main] ORDER BY [Call Sign]";
                    
                    SqlDataAdapter adp = new SqlDataAdapter(sqlcmd);
    
                    DataTable dtRecord = new DataTable();
                    adp.Fill(dtRecord);
                    dataGridView1.DataSource = dtRecord;
                    dataGridView1.Refresh();
                }
                dataGridView1.ClearSelection();
    
                if (selI == "Profit")
                {
                    sqlcmd.CommandText = "SELECT [Call Sign] AS Call_Sign, [Current Price] AS Current_Price, [Profit], [Buy], [Sell], [Available Money] AS Available_Money, [Quantity Bought] AS Quantity_Bought FROM [Main] ORDER BY [Profit] DESC, [Quantity Bought] DESC, [Call Sign]";
    
                    SqlDataAdapter adp = new SqlDataAdapter(sqlcmd);
    
                    DataTable dtRecord = new DataTable();
                    adp.Fill(dtRecord);
                    dataGridView1.DataSource = dtRecord;
                    dataGridView1.Refresh();
                }
    
                if (selI == "System Logs")
                {
                    sqlcmd.CommandText = "SELECT [Time], [Module], [Error Code] AS Error_Code, [Restart] FROM [Error] ORDER BY [Time], [Module], [Restart]";
    
                    SqlDataAdapter adp = new SqlDataAdapter(sqlcmd);
    
                    DataTable dtRecord = new DataTable();
                    adp.Fill(dtRecord);
                    dataGridView1.DataSource = dtRecord;
                    
                    dataGridView1.Refresh();
                }

    string table = "";
    List<object> cols = new List<object>();
    List<string> stringArr = new List<string>();
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        src = srcTxt.Text;
        table = tableCB.Text;
        string output = outTxt.Text;
        string scriptString = "";
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + src;
        using (OleDbConnection connection = new OleDbConnection(connString))
        {
            connection.Open();
            OleDbDataReader reader = null;
            OleDbCommand command = new OleDbCommand("SELECT * FROM " + table, connection);
            reader = command.ExecuteReader();
    
    
    
            var tabName = reader.GetSchemaTable();
            var nameCol = tabName.Columns["ColumnName"];
            foreach (DataRow row in tabName.Rows)
            {
                cols.Add("`" + row[nameCol] + "`");
            }
            var result = string.Join(",", cols);
    
    
    
            // scriptString = "INSERT INTO `" + table + "` (" + result + ") VALUES \n";
    
    
            // int n = 0;
            // while (++n < tabName.Rows.Count)
            // {
                // stringArr.Add("reader.GetString(" + n + ")");
            // }
    
            // var strValue = string.Join(",", stringArr);
            // while (reader.Read())
            // {
    
                // scriptString += "(" + strValue + "),\n";
            // }
    		while(reader.Read())
    		{
    			scriptString += "INSERT  INTO `" + table + "` (" + result + ") VALUES \n (";
    			int n = 0;
    			while (++n < tabName.Columns.Count)
    			{
    				stringArr.Add(reader.GetValue(n).ToString());
    			}
    			var strValue = string.Join(",", stringArr);
    			scriptString += strValue + "); \n";
    		}
    		
        }
        File.WriteAllText(output, scriptString += ";");
    }

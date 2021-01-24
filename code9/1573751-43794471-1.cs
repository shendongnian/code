    private void PasteFromExcel()
    {
    	DataTable tbl = new DataTable();
    	tbl.TableName = "ImportedTable";
    	List<string> data = new List<string>(ClipboardData.Split('\n'));
    	bool firstRow = true;
    
    	if (data.Count > 0 && string.IsNullOrWhiteSpace(data[data.Count - 1]))
    	{
    		data.RemoveAt(data.Count - 1);
    	}
    
    	foreach (string iterationRow in data)
    	{
    		string row = iterationRow;
    		if (row.EndsWith("\r"))
    		{
    			row = row.Substring(0, row.Length - "\r".Length);
    		}
    
    		string[] rowData = row.Split(new char[] { '\r', '\x09' });
    		DataRow newRow = tbl.NewRow();
    		if (firstRow)
    		{
    			int colNumber = 0;
    			foreach (string value in rowData)
    			{
    				if (string.IsNullOrWhiteSpace(value))
    				{
    					tbl.Columns.Add(string.Format("[BLANK{0}]", colNumber));
    				}
    				else if (!tbl.Columns.Contains(value))
    				{
    					tbl.Columns.Add(value);
    				}
    				else
    				{
    					tbl.Columns.Add(string.Format("Column {0}", colNumber));
    				}
    				colNumber++;
    			}
    			firstRow = false;
    		}
    		else
    		{
    			for (int i = 0; i < rowData.Length; i++)
    			{
    				if (i >= tbl.Columns.Count) break;
    				newRow[i] = rowData[i];
    			}
    			tbl.Rows.Add(newRow);
    		}
    	}
    
    	DataGridView1.DataSource = tbl;
    }

    ArrayList myArrayList = new ArrayList();
    
    for (int i = 0; i <= dt.Rows.Count - 1; i++)
    {
    	for (int j = 0; j <= dt.Columns.Count - 1; j++)
    	{
    		myArrayList.Add(dt.Rows[i][j].ToString());
    	}
    }
    
    StringBuilder strb = new StringBuilder();
    
    foreach (var item in myArrayList)
    {
    	strb.Append(item + ";");
    }

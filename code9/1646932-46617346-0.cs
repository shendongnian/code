    int idx = ColumnsNameData.IndexOf(":");
    
    if (idx == -1) 
    {
        // Do something here. You can throw an exception or return
    }
    
    string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
    if (!ColumnsName.Contains(ColumnsNameString))
    {
        ColumnsName.Add(ColumnsNameString);
    }

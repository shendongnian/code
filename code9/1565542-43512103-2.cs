    public bool IsRowEmpty(DataRow row)
    {
        if (row == null)
            return true;    
    
        foreach(var value in row.ItemArray)
        {
            if (value != null)
                return false;
        }
        return true;
    }

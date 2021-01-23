    public string GetTableType(string tableName)
    {
        switch (tableName)
        {
            case "limit":
                return "A_TypeTable";
            case "health":
                return "B_TypePolicy";                  
            default:
                return "C_TypeTable";
        }
    
    }

    List<string> conditions = new List<string>();
    if (price1 != null)
    {
        cmd.Parameters.Add("@param1", price);
        conditions.Add(" price >= @param1 ");
    }
    
    if (price2 != null)
    {
        cmd.Parameters.Add("@param2");
        conditions.Add(" price <= @param2 ");
    }
    
    .....
    
    StringBuilder sb = new StringBuilder();
    sb.Append("select * from legacy ");
    if(conditions.Count > 0)
    {
        sb.Append("WHERE ");
        sb.Append(string.Join(" AND ", conditions));
    }

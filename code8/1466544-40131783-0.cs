    List<string>condition = new List<string>();
    foreach (ListItem li in ddlStatus.Items)
    {
        if(li.Selected) condition.Add($"'{li.Value}'");
    } 
    string whereCondition = string.Empty;
    if (condition.Count > 0)
    {
        whereCondition = " Where type IN (" + 
                           string.Join(",", condition) + 
                           ")";
    }
     
    using (OracleConnection conn = new OracleConnection(constr))
    {
        using (OracleCommand cmd = new OracleCommand(strQuery + whereCondition))
        {
           ....

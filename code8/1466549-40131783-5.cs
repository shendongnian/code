    // Create a list of your conditions to put inside the IN statement
    List<string>conditions = new List<string>();
    foreach (ListItem li in ddlStatus.Items)
    {
        if(li.Selected) 
           conditions.Add($"'{li.Value}'");
    } 
    // Now build the where condition used
    string whereCondition = string.Empty;
    if (condition.Count > 0)
    {
        // This produces something like "WHERE type in ('10', '11', '12')"
        // The values for the IN are directly concatenated together
        whereCondition = " Where type IN (" + string.Join(",", conditions) + ")";
    }
     
    using (OracleConnection conn = new OracleConnection(constr))
    {
        using (OracleCommand cmd = new OracleCommand(strQuery + whereCondition))
        {
           ....

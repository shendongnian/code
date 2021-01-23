    int count = 1;
    List<OracleParameter> parameters = new List<OracleParameter>();
    List<string>conditions = new List<string>();
    foreach (ListItem li in ddlStatus.Items)
    {
        if(li.Selected) 
        {
           conditions.Add($":p{i}");
           OracleParameter p = new OracleParameter($":p{i}",OracleType.NVarChar);
           p.Value = li.Value;
           parameters.Add(p);
           i++;
        }
    } 
    if (condition.Count > 0)
    {
        whereCondition = " Where type IN (" + 
                           string.Join(",", conditions) + 
                           ")";
    }
     
    using (OracleConnection conn = new OracleConnection(constr))
    {
        using (OracleCommand cmd = new OracleCommand(strQuery + whereCondition))
        {
           cmd.Parameters.AddRange(parameters.ToArray());
           ....

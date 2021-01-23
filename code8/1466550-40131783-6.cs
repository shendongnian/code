    int count = 1;
    List<OracleParameter> parameters = new List<OracleParameter>();
    List<string>conditions = new List<string>();
    foreach (ListItem li in ddlStatus.Items)
    {
        if(li.Selected) 
        {
           // parameters are named :p1, :p2, :p3 etc...
           conditions.Add($":p{count}");
           // Prepare a parameter with the same name of its placeholder and
           // with the exact datatype expected by the column Type, assign to
           // it the value and add the parameter to the list
           OracleParameter p = new OracleParameter($":p{count}",OracleType.NVarChar);
           p.Value = li.Value;
           parameters.Add(p);
           count ++;
        }
    } 
    if (condition.Count > 0)
    {
        // This produces something like "WHERE type in (:p1, :p2, :p3)"
        // The values are stored before in the parameter list
        whereCondition = " Where type IN (" + string.Join(",", conditions) + ")";
    }
     
    using (OracleConnection conn = new OracleConnection(constr))
    {
        using (OracleCommand cmd = new OracleCommand(strQuery + whereCondition))
        {
           // Add the parameters with the expected names, type and value.
           cmd.Parameters.AddRange(parameters.ToArray());
           ....

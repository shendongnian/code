    public OleDbCommand GetPoles(List<int> polesID)
    {
        // Base text of the query
        string cmdText = @"SELECT * FROM TABLE1 WHERE Pole1 IN(";
        // where we store the 'name' of the parameters. (OleDb doesn't care)
        List<string> inClause = new List<string>();
        // where we store the parameters and their values
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        foreach(int id in polesID)
        {
            // Add a placeholder for the parameter
            inClause.Add("?");
            // Build the parameter and store it away
            OleDbParameter p = new OleDbParameter("p" + id.ToString(), OleDbType.Integer);
            p.Value = id;
            parameters.Add(p);
        }
        OleDbCommand cmd = new OleDbCommand();
        // Build the command text: IN(?,?,?). A ? placeholder for each parameter
        cmd.CommandText = cmdText + string.Join(",", inClause.ToArray()) + ")";
        // pass all the parameters to the command and return it
        cmd.Parameters.AddRange(parameters.ToArray());
        return cmd;
    }

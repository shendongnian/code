    public OdbcCommand MakeCommand(List<string> names) {
        List<OdbcParameter> parameters = new List<OdbcParameter>();
        List<string> placeholders = new List<string>();
        foreach(string name in names) {
            OdbcParameter p = new OdbcParameter("?", OdbcType.NVarChar);
            p.Value = name;
            parameters.Add(p);
            placeholders.Add("?")
        }
        string command = "SELECT name, value FROM my_table WHERE name IN(";
        command = command + string.Join(",", placeholders.ToArray()) + ")";
        OdbcCommand cmd = new OdbcCommand();
        cmd.CommandText = command;
        cmd.Parameters.AddRange(parameters.ToArray());
        return cmd;
    }

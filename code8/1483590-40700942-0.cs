    private static string GetSqlCommandTextForLogs(SqlCommand cmd)
    {
        string text = cmd.CommandText;
        foreach (SqlParameter parameter in cmd.Parameters)
        {
            text = text.Replace("@"+parameter.ParameterName, parameter.Value.ToString());
        }
        return text;
    }

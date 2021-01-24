    public static IEnumerable<T> Get(IComplianceConnection complianceConnection, string query, object arguments)
    {
        IList<T> entities;
        using (var connection = complianceConnection.OpenConnection())
        {
            entities = connection.Query<T>(query, arguments, commandType: CommandType.StoredProcedure).ToList();
        }
        return entities;
    }

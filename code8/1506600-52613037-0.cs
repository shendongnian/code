cs
using Oracle.ManagedDataAccess.Client;
public void ExecuteQuery(string queryString, string connectionString)
{
    using (OracleConnection connection = new OracleConnection(connectionString))
    {
        OracleCommand command = new OracleCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
}

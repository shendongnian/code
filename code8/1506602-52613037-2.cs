cs
using Oracle.ManagedDataAccess.Client;
public void Execute(string queryString, string connectionString)
{
    using (OracleConnection connection = new OracleConnection(connectionString))
    {
        OracleCommand command = new OracleCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
}
Basically you can use it exactly like the official .NET System.Data.SqlClient (easy to find online tutorials for this) and just replace everywhere in the code SqlConnection with OracleConnection and SqlCommand with OracleCommand.

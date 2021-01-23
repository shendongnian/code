     internal class Prozedur : IDbCommand
        {
            private static SqlCommand command = new SqlCommand();
            private static SqlConnection connection;
            static string commandtext;
            CommandType commandType;
            public Prozedur(string abfrage)
            {
                commandtext = abfrage;
                commandType = CommandType.StoredProcedure;
                connection = (SqlConnection)new Verbindung();
            }
            public static explicit operator SqlCommand(Prozedur v)
            {
                return new SqlCommand() { CommandText = commandtext, Connection = connection, CommandType = command.CommandType };
            }
    ...

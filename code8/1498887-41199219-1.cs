        internal class Prozedur : IDbCommand
        {
            private SqlCommand command = new SqlCommand();
            private SqlConnection connection;
            string commandtext;
            CommandType commandType;
            public Prozedur(string abfrage)
            {
                commandtext = abfrage;
                commandType = CommandType.StoredProcedure;
                connection = (SqlConnection)new Verbindung();
            }
            public static explicit operator SqlCommand(Prozedur v)
            {
                return new SqlCommand() { CommandText = v.CommandText, Connection = (SqlConnection)v.Connection, CommandType = v.CommandType };
            }
    ...

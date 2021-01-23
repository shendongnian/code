    Public class SqlHelper
    {
        string commandText;
        string connectionString;
        public SqlHelper(string command, string connection)
        {
            commandText = command;
            connectionString = connection;
        }
        public DataTable Select()
        {
            var table = new DataTable();
            using (var adapter = new SqlDataAdapter(this.commandText, this.connectionString))
                adapter.Fill(table)
            return table;
        }
        public void Update(DataTable table)
        {
            using (var adapter = new SqlDataAdapter(this.commandText, this.connectionString))
            {
                var builder = new SqlCommandBuilder(adapter);
                adapter.Update(table);
            }
        }
    } 

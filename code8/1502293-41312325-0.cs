    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new System.Data.OleDb.OleDbConnection{ConnectionString = ".. your connection string .."})
            {
                connection.Open();
                Console.WriteLine("DataSource: {0}, database: {1}",connection.DataSource, connection.Database);
            }         
        }
    }

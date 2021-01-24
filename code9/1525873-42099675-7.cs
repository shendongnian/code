    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        string connectionString = "Server=(local);Database=Sample;Trusted_Connection=True;";
    
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
    
            using (var command = connection.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "procMergePageView";
    
                var p1 = command.CreateParameter();
                command.Parameters.Add(p1);    
                p1.ParameterName = "@Display";
                p1.SqlDbType = System.Data.SqlDbType.Structured;
                var items = PageViewTableType.Generate(100);
                using (DbDataReader dr = new ObjectDataReader<PageViewTableType>(items))
                {
                    p1.Value = dr;
                    command.ExecuteNonQuery();
                }    
            }
        }
    }
    
    class PageViewTableType
    {
        // Must match the name of the column of the TVP
        public long PageViewID { get; set; }
    
        // Generate dummy data
        public static IEnumerable<PageViewTableType> Generate(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new PageViewTableType { PageViewID = i };
            }
        }
    }

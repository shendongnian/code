    class Program
    {
        static string connectionString = @"xxxxxxxxxx";
        static void Main(string[] args)
        {
            Console.WriteLine("Input name: ");
            var name = Console.ReadLine();
            IEnumerable<TestClass> results;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FName", name, DbType.String, ParameterDirection.Input, 20);
                results = db.Query<TestClass>("Procedure", 
                    commandType: CommandType.StoredProcedure,
                    param: parameters);
            }
            foreach(var result in results)
            {
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
    }
    class TestClass
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"FName: {FName}, LName: {LName}, Age: {Age}";
        }
    }

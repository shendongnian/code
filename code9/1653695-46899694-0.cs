    static void Main(string[] args)
        {
            Console.WriteLine("Inserting ...");
    
            var userId = 777;
            var productIds = new List<int> { 1, 2, 3, 4 };
            var dto = new Dictionary<int, List<int>>
            {
                { userId, productIds }
            };
    
            ExecuteBulkInsert(dto);
            // ExecuteProcedure(dto);
    
            Console.WriteLine("Done! ...");
            Console.ReadLine();
        }
    
        public static void ExecuteBulkInsert( Dictionary<int, List<int>> dto)
        {
            string connectionString = GetConnectionString();
    
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable newProducts = CreateDataTable(dto);
    
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "dbo.UserProducts";
                    bulkCopy.WriteToServer(newProducts);
                }
            }
        }
    
        private static DataTable CreateDataTable(Dictionary<int, List<int>> dto)
        {
            const string IdUserColumnName = "IdUser";
            const string IdProductColumnName = "IdProduct";
    
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn(IdUserColumnName, typeof(int)));
            table.Columns.Add(new DataColumn(IdProductColumnName, typeof(int)));
    
            foreach (var product in dto)
            {
                foreach (var productId in product.Value)
                    table.Rows.Add(product.Key, productId);
            }
    
            return table;
        }
    

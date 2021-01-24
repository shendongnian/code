    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddDataReaderMapping();                
                cfg.CreateMap<IDataReader, Category>();
            });
            using (var conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True"))
            using (var cmd = new SqlCommand("SELECT CategoryID, CategoryName FROM Categories", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {                    
                    var res2 = Mapper.Map<IDataReader, List<Category>>(reader);
                }
            }            
        }
    }

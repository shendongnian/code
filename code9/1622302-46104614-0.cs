    /// <summary>
    /// DTO
    /// </summary>
    public class CustomerOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    /// <summary>
    /// Define a contract that get a sequence of something
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFetch<T>
    {
        IEnumerable<T> Fetch();
    }
    /// <summary>
    /// Define a pageTemplate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PageTemplate<T> : IFetch<T>
    {
        protected readonly int pageSize;
        protected readonly int page;
        public PageTemplate(int page, int pageSize)
        {
            this.page = page;
            this.pageSize = pageSize;
        }
        public abstract IEnumerable<T> Fetch();
    }
    /// <summary>
    /// Design a MyDto Page object, Here you are using the Template method
    /// </summary>
    public abstract class MyDtoPageTemplate : PageTemplate<CustomerOrder>
    {
        public MyDtoPageTemplate(int page, int pageSize) : base(page, pageSize) { }
    }
    /// <summary>
    /// You can use ado.net for full performance or create a derivated class of MyDtoPageTemplate to use Dapper
    /// </summary>
    public sealed class SqlPage : MyDtoPageTemplate
    {
        private readonly string _connectionString;
        public SqlPage(int page, int pageSize, string connectionString) : base(page, pageSize)
        {
            _connectionString = connectionString;
        }
        public override IEnumerable<CustomerOrder> Fetch()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //This can be injected from contructor or encapsulated here, use a Stored procedure, is fine
                string commandText = "Select Something";
                using (var command = new SqlCommand(commandText, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) yield break;
                        while (reader.Read())
                        {
                            yield return new CustomerOrder()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Value = reader.GetString(2)
                            };
                        }
                    }
                }
            }
        }
    }
    public sealed class MongoDbPage : MyDtoPageTemplate
    {
        private readonly string _connectionString;
        public MongoDbPage(int page, int pageSize, string connectionString) : base(page, pageSize)
        {
            _connectionString = connectionString;
        }
        public override IEnumerable<CustomerOrder> Fetch()
        {
            //Return From CustomerOrder from mongoDb
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// You can test and mock the fetcher
    /// </summary>
    public sealed class TestPage : IFetch<CustomerOrder>
    {
        public IEnumerable<CustomerOrder> Fetch()
        {
            yield return new CustomerOrder() { Id = 0, Name = string.Empty, Value = string.Empty };
            yield return new CustomerOrder() { Id = 1, Name = string.Empty, Value = string.Empty };
        }
    }
    public class AppCode
    {
        private readonly IFetch<CustomerOrder> fetcher;
        /// <summary>
        /// From IoC, inject a fetcher object
        /// </summary>
        /// <param name="fetcher"></param>
        public AppCode(IFetch<CustomerOrder> fetcher)
        {
            this.fetcher = fetcher;
        }
        public IEnumerable<CustomerOrder> FetchDtos()
        {
            return fetcher.Fetch();
        }
    }
    public class CustomController
    {
        private readonly string connectionString;
        public void RunSql()
        {
            var fetcher = new SqlPage(1, 10, connectionString);
            var appCode = new AppCode(fetcher);
            var dtos = appCode.FetchDtos();
        }
        public void RunTest()
        {
            var fetcher = new TestPage();
            var appCode = new AppCode(fetcher);
            var dtos = appCode.FetchDtos();
        }
    }

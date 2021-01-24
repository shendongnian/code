    public class ClassToTest
    {
        private readonly IRepository _repository;
        public ClassToTest(IRepository repository)
        {
           _repository = repository;
        }
    
        // Doesn't necessarily need to be async
        public Task DoSomething() 
        {
            // We're return the wrapped task directly, and adding no additional value.
            return repository.ExecuteAsync();
        }
    }
    
    public class Repository : IRepository
    {
        public async Task ExecuteAsync()
        {
            using (var connection = new SqlConnection(DbConfiguration.DatabaseConnection))
            {
                // Here we do need to await, otherwise we'll dispose the connection
                return await connection.ExecuteAsync(storedProcedure, parameters, 
                  commandType: CommandType.StoredProcedure, 
                  commandTimeout: Configuration.TransactionTimeout);
            }
        }
    }
    
    // NUnit has full support for async / await
    [Test]
    public async Task TestMethod()
    {
        var repository = new Mock<IRepository>();
        var classToTest =  new ClassToTest(repository.Object);
        repository.Setup(_ => _.ExecuteAsync()).Returns(Task.FromResult((object)null));
        // Moq also has support for async, e.g. .ReturnsAsync
        // You need to await the test.
        await classToTest.DoSomething();
    
        repository.Verify(p => p.ExecuteAsync(), Times.Once());
    }

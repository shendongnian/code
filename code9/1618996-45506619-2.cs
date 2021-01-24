    [TestFixture]
    public class LoadFinishedTrzlBatchTest {
        private LoadFinishedTrzlBatch sut;
        //need this later so declaring as field.
        private IGenericRepository<ProductionOrder> proOrdRepository;
        [SetUp]
        public void SetUpLoadFinishedTrzlBatch() {  
            //Not using these so they can be declared locally          
            var batchRepository =
                Mock.Create<IGenericRepository<Batch>>();
            var codeRepository =
                Mock.Create<IGenericRepository<Code>>();
            var aggRepository =
                Mock.Create<IGenericRepository<Aggregation>>();
            var aggChildrenRepository =
                Mock.Create<IGenericRepository<AggregationChildren>>();
            //initializing target mock
            proOrdRepository = 
                Mock.Create<IGenericRepository<ProductionOrder>>();
            sut = new LoadFinishedTrzlBatch(
                proOrdRepository,
                batchRepository,
                codeRepository,
                aggRepository,
                aggChildrenRepository);
        }
    
        [Test]
        public void ShouldExistsProductionOrder()
        {
            // Arrange
            var productionOrderName = "ProOrd";
            var orders = new List<ProductionOrder>() {
                new ProductionOrder { Name = productionOrderName },
                new ProductionOrder { Name = "Dummy for Filter" }
            };
            Mock.Arrange(() => proOrdRepository
                .SearchFor(Arg.IsAny<Expression<Func<ProductionOrder,bool>>>()))
                .Returns((Expression<Func<ProductionOrder,bool>> expression) => 
                    orders.Where(expression.Compile()).AsQueryable()
                )
                .MustBeCalled();
    
            // Act
            var actual = sut.ExistsProductionOrder(productionOrderName);
    
            // Assert
            Assert.IsTrue(actual);
        }
    }

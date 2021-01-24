    namespace WarehouseTemplate.Tests
    {
        [TestFixture]
        public class TestDao : AbstractDaoIntegrationTests
        {
            private IProductDao productDao;
    
            private ISessionFactory sessionFactory;
    
            // These properties will be injected based on type
            public IProductDao ProductDao
            {
                set { productDao = value; }
            }
            public ISessionFactory SessionFactory
            {
                set { sessionFactory = value; }
            }
    
            [SetUp]
            public void Init()
            {
            }
    
            [Test()]
            public void CustomerDaoTests()
            {//logic here
    
            }
        }
    }

    namespace WarehouseTemplate.Tests
    {
        [TestFixture]
        public class Test1  
        {
           
    
            [SetUp]
            public void Init()
            {
               
            }
    
            [Test()]
            public void Can_generate_schema()
            {
                var cfg = new Configuration();
    
                cfg.Configure();
    
                new SchemaExport(cfg).Execute(true, true, false);
    
            }
        }
    }

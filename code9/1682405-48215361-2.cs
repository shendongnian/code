    namespace WarehouseTemplate.Tests
    {
        [TestFixture]
        public class AbstractDaoIntegrationTests : AbstractTransactionalDbProviderSpringContextTests
        {
            protected override string[] ConfigLocations
            {
                get
                {
                    return new string[]
                        {
                            "referenceString"
                        };
                }
            }
        }
    }

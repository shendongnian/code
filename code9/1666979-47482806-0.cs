        [TestFixture]
        public class CarsControllerTest
        {
                public CarsControllerTest()
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.AddProfile<AutoMapperProfile>();
                    });
                }
        }

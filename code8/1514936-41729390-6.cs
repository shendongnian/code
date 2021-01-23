      [TestClass] 
      public class AuctionControllerTests: TestControllerBase<AuctionController> 
      {
        
        public AuctionController TargetController { 
          get {return new AuctionController();//inject your mocked dependencies}}
        
        [TestInitialize]
        public void SetUp()
        {
            TargetSetup()
        }
      }

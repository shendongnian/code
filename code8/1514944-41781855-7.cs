    [TestClass]
    public class AuctionControllerTest : ControllerTestBase<AuctionController, Auction, MobileServiceContext>
    {
        [TestMethod]
        public void Fetch_All_Existing_Items()
        {
            Assert.AreEqual(1, Controller.GetAllAuction().ToList().Count);
        }
    }

    [TestClass]
    public class TourObjectControllerTest
    {
        [TestMethod]
        public async Task GetTourObjects()
        {
            var fakeData = new List<TourObjectDTO>() {
                new TourObjectDTO { ... }
            };
            var mockService = new Mock<ITourObjectService>(MockBehavior.Default);
            mockService.Setup(x => x.GetAll()).ReturnsAsync(fakeData);
            var controller = new TourObjectController(mockService.Object);
            var result = await controller.Get();
            Assert.IsNotNull(result);
            Assert.AreSame(typeof(TourObjectViewModel), result);
        }
    }

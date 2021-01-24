    public interface IService {
        event EventHandler OnResultsChanged;
    }
    public class Provider {
        private IService _service;
        public Provider(IService service) {
            _service = service;
            _service.OnResultsChanged += ChangeResults;
        }
        private async void ChangeResults(object sender, EventArgs e) {
            await Task.Delay(200); //<-- simulate delay
            await Task.Run(() => HasResults = true);
        }
        public bool HasResults { get; set; }
    }
    [TestClass]
    public class MyTestClass {
        [TestMethod]
        public async Task Test() {
            //Arrange
            var serviceMock = new Mock<IService>();
            var systemUnderTest = new Provider(serviceMock.Object) {
                HasResults = false
            };
            //Act
            serviceMock.Raise(mock => mock.OnResultsChanged += null, EventArgs.Empty);
            await Task.Delay(300); //<--wait
            //Assert
            Assert.IsTrue(systemUnderTest.HasResults);
        }
    }

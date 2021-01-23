    [UnitTest]
    public class InfluxClientTests {
        [TestMethod]
        public async Task InfluxClient_Should_Get_All_Users() {
            //Arrange        
            var client = new InfluxClient(new Uri("http://localhost:8086"));
            //Act
            var users = await client.ShowUsersAsync();
    
            //Assert
            //...verify expected results.
        }
    }

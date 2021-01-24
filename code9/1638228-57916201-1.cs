        public class MyControllerTest: IClassFixture<TestSetup>
        {
            private ServiceProvider _serviceProvider;
            private MyController _myController;
        
            public MyControllerTest(TestSetup testSetup)
            {
               _serviceProvider = testSetup.ServiceProvider;
               _myController = _serviceProvider.GetService<MyController>();
            }
        
            [Fact]
            public async Task GetUserShouldReturnOk()
            {
                var result = await _myController.GetUser(userId);
                Assert.IsType<OkResult>(result);
            }
        
        }

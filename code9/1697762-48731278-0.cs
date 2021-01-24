    public class FooterViewComponentTest
    {
        public class Should
        {
            [Fact]
            public void ReturnViewCompnentWithViewModel()
            {
                // Arrange
                var appSettings = new AppSettings.Application();
                appSettings.AppName = "app";
                appSettings.Version = "1.0";
                var optionsMock = new Mock<IOptions<AppSettings.Application>>();
                optionsMock.SetupGet(o => o.Value).Returns(appSettings);
                var hostingMock = new Mock<IHostingEnvironment>();
                hostingMock.SetupGet(h => h.Environment).Returns("Test");
                var viewComp = new FooterViewComponent(optionsMock.Object, hostingMock.Object);
    
                // Act
                var result = viewComp.Invoke();
    
                // Assert
                Assert.IsType<ViewComponentResult>(result);
    
            }
        }
    }

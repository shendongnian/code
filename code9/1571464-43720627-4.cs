    [TestClass]
    public class NewsControllerTest {
        [TestMethod]
        public void _NewsList() {
            //Arrange           
            var companyId = 1;
            var companyType = "someType";
            var claims = new List<Claim>
            {
                new Claim("UserName", "admin"),
                new Claim("CompanyType", companyType),
            };
            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            var contextMock = new Mock<HttpContextBase>();
            contextMock.Setup(_ => _.User).Returns(principal);
            var fakeNews = new List<News>() { new News(), new News() };
            var mockNewsService = new Mock<INewsService>();
            mockNewsService
                .Setup(_ => _.List(It.IsAny<string>(), It.IsAny<string>())
                .Returns(fakeNews);
            var controller = new NewsController(mockNewsService.Object, Mock.Of<IMapper>());
            controller.ControllerContext = new ControllerContext(contextMock.Object, new RouteData(), controller);
            
            // Act
            ViewResult result = controller.List(companyId) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
            mockNewsService.Verify(_ => _.List(It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce);
        }
    }

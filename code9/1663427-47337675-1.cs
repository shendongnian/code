    [TestClass]
    public class UrlHelperFactory_Should {
        public class MyTestEntity {
            public string NavigateUrl {
                get {
                    var urlHelper = UrlHelperFactory.Create();
                    string url = urlHelper.Action("SomeAction", "MyController");
                    return url;
                }
            }
        }
        [TestMethod]
        public void Generate_NavigationUrl() {
            //Arrange
            var mockHelper = Mock.Of<IUrlHelper>();
            UrlHelperFactory.Create = () => {
                return mockHelper;
            };
            var expected = "http://my_fake_url";
            Mock.Get(mockHelper)
                .Setup(_ => _.Action(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(expected);
            var sut = new MyTestEntity();
            //Act
            var actual = sut.NavigateUrl;
            //Assert
            actual.Should().NotBeNullOrWhiteSpace()
                .And.Be(expected);
        }
    }

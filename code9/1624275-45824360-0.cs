    public class NewsControllerTests
        {
            private IContainer _testContainer;
            private NewsController _controller;
    
            public NewsControllerTests()
            {
                Mapper.Initialize(config =>
                {
                    config.CreateMap<News, NewsDto>();
                    config.CreateMap<NewsDto, News>();
                });
    
                _testContainer = RegisterTestDependencies.testContainer = new Container(rules => rules.With(FactoryMethod.ConstructorWithResolvableArguments)).WithWebApi(
                    new HttpConfiguration(), throwIfUnresolved: type => type.IsController());
    
                RegisterTestDependencies.InitializeTestContainer(_testContainer);
    
            }
           [Fact]
            void GetNews_WithoutId_ReturnsAllNewsItems()
            {
                //Arrange
            using (var scope = _testContainer.OpenScope(Reuse.WebRequestScopeName))
            {
                _controller = scope.Resolve<NewsController>();
                //Act
                var getNewsResult = _controller.GetNews() as OkNegotiatedContentResult<List<NewsDto>>;
                //Assert
                getNewsResult.Content.Should().AllBeOfType<NewsDto>();
            }
        }
    }

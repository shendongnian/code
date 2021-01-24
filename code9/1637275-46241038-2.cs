    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void Test_EmailArticleController_With_RenderingContext() {
            //Arrange
            var businessLogicFake = new Mock<IEmailArticleBusiness>();
    
            var model = new EmailArticleViewModel() {
                ArticleControl  = new Article_Control() { },
                Metadata = new Metadata() { }
            };
    
            businessLogicFake.Setup(x => x.FetchPopulatedModel).Returns(model);
    
            var datasourceId = "fake_datasourceId";
            var renderingContext = Mock.Of<IRenderingContext>(_ => _.GetDataSource() == datasourceId);
    
            var controllerUnderTest = new EmailArticleController(businessLogicFake.Object, renderingContext);
    
            //Act
            var result = controllerUnderTest.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
            businessLogicFake.Verify(_ => _.SetDataSourceID(datasourceId), Times.AtLeastOnce());
        }
    }

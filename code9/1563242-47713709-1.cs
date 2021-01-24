    public class BlogControllerTest
    {
      private XunitLogger<BlogController> _logger;
      public BlogControllerTest(ITestOutputHelper output){
        _logger = new XunitLogger<BlogController>(output);
      }
      [Fact]
      public void Index_ReturnAViewResult_WithAListOfBlog()
      {
        var mockRepo = new Mock<IDAO<Blog>>();
        mockRepo.Setup(repo => repo.GetMany(null)).Returns(GetListBlog());
        var controller = new BlogController(_logger,mockRepo.Object);
        // rest
      }
    }

     public class ProductController : Controller
     {
          public ActionResult Index()
          {
               // Add action logic here
               throw new NotImplementedException();
          }
          public ActionResult Details(int Id)
          {
               return View("Details");
          }
     }
     [TestFixture]
     public class ProductControllerTest
     {
          [Test]
          public void TestDetailsView()
          {
               var controller = new ProductController();
               var result = controller.Details(2) as ViewResult;
               Assert.AreEqual("Details", result.ViewName);
          }
     }

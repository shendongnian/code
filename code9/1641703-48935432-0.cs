    public class HomeBottomContentController : GlassController
    {
    ISitecoreContext _iSitecoreContext;
     
    public HomeBottomContentController() :this(new SitecoreContext()){
    }
    public HomeBottomContentController(ISitecoreContext iSitecoreContext)
    {
        _iSitecoreContext = iSitecoreContext;
    }
   
    public ActionResult IndexTest()
    {
        var model = _iSitecoreContext.GetCurrentItem<Home_Control>();
        return View("~/Views/HomeBottomContent/HomeBottomContent.cshtml", model);
    }
    
    }
    [TestClass]
    public class MvcUnitTests
    {
    [TestMethod]
    public void Test_HomeBottomContentController_With_ISitecoreContext()
    {
       
        var model = new Home_Control()
        { Bottom_Content = "XYZ" };
        var iSitecoreContext = new Mock<Glass.Mapper.Sc.ISitecoreContext>();
        iSitecoreContext.Setup(_ => _.GetCurrentItem<Home_Control>(false, false)).Returns(model);
        HomeBottomContentController controllerUnderTest = new HomeBottomContentController(iSitecoreContext.Object);
        var result = controllerUnderTest.IndexTest() as ViewResult;
       
    }

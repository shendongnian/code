    public class HomeBottomContentController : GlassController
    {
        public override ActionResult Index()
        {
            var context = this.GetContext();
            var model = context.GetCurrentItem<Home_Control>();
            return View("~/Views/HomeBottomContent/HomeBottomContent.cshtml", model);
        }
    	
    	protected virtual SitecoreContext GetContext() 
    	{
    		return new SitecoreContext();
    	}
    }
    
    [TestClass]
    public class MvcUnitTests
    {
        [TestMethod]
        public void Test_HomeBottomContentController_With_ISitecoreContext()
        {     
            var controllerUnderTest = new FakeHomeBottomContentController();
    		controllerUnderTest.FakeContext = /* set what you want */;
            var result = controllerUnderTest.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);        
        }
    	
    	public class FakeHomeBottomContentController : HomeBottomContentController 
    	{
    		public SitecoreContext FakeContext { get; set; }
    		
    		protected override SitecoreContext GetContext()
    		{
    			return this.FakeContext;
    		}
    	}	
    }

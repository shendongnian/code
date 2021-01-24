    public class HomeBottomContentController : GlassController
    {
    	private readonly ISitecoreContext _iSitecoreContext;
    	public HomeBottomContentController(ISitecoreContext iSitecoreContext)
    	{
    		_iSitecoreContext = iSitecoreContext;
    	}
    
    	public override ActionResult Index()
    	{
    		var model = this.GetCurrentItem();
    		return View("~/Views/HomeBottomContent/HomeBottomContent.cshtml", model);
    	}
    	
    	protected virtual Home_Control GetCurrentItem() 
    	{
    		return _iSitecoreContext.GetCurrentItem<Home_Control>();
    	}
    }
    
    namespace WTW.Feature.HomeBottomContent.Tests
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void Test_ISitecoreContextInsertion()
            {       
    			var iSitecoreContext = Mock.Of<Glass.Mapper.Sc.ISitecoreContext>();
                var controllerUnderTest = new FakeHomeBottomContentController(iSitecoreContext);
                var result = controllerUnderTest.Index() as ViewResult;
                Assert.IsNotNull(result);
            }
        }
    	
    	public class FakeHomeBottomContentController : HomeBottomContentController 
    	{
    		public FakeHomeBottomContentController(ISitecoreContext iSitecoreContext) : base(iSitecoreContext) 
    		{
    		}
    		
    		protected override Home_Control GetCurrentItem()
    		{
    			// return instance of Home_Control type
    			// e.g.			
    			return new Home_Control();
    		}
    	}
    }

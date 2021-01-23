    public class HomeApiController : ApiController
        {
            private IWebSettingBll _webSettingBll;
            private IPageBll _pageBll;
            private IHomeBll _homeBll;
            private readonly IHitCountBll _hitCountBll;
            public HomeApiController(IWebSettingBll webSettingBll,IHitCountBll hitCountBll,IPageBll pageBll,IHomeBll homeBll)
            {
                _hitCountBll = hitCountBll;
                _webSettingBll = webSettingBll;
                _homeBll = homeBll;
                _pageBll = pageBll;
            }
    
        }

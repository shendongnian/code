    public class ToolbarControllerContext
    {
        [Dependency]
        public IToolbarLogic ToolbarLogic { get; set; }
    }
    
    public class ToolbarController : BaseController
    {    
        private readonly IToolbarLogic _toolbarLogic;
    
        public ToolbarController(ToolbarControllerContext context)
        {
            _toolbarLogic = context.ToolbarLogic;
        }
    
    
        // GET: Common/Toolbar
        public ActionResult Toolbar()
        {
            bool ShowConfidential = _toolbarLogic.ShowConfidential();
            string linkHome = _toolbarLogic.BindHome(base.User.Identity.Name);
            return PartialView(new ToolbarModel() {
                ShowConfidential = ShowConfidential,
                lnkHome = linkHome
            });
            return PartialView();
        }
    }

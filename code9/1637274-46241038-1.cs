    public class EmailArticleController : GlassController {
        private readonly IEmailArticleBusiness businessLogic;
        private readonly IRenderingContext renderingContext;
    
        public EmailArticleController(IEmailArticleBusiness businessLogic, IRenderingContext renderingContext) {
            this.businessLogic = businessLogic;
            this.renderingContext = renderingContext;
        }
    
        public ActionResult Index() {
            var model = businessLogic.FetchPopulatedModel;
            var datasourceId = renderingContext.GetDataSource();
            businessLogic.SetDataSourceID(datasourceId);
            return View("~/Views/EmailCampaign/EmailArticle.cshtml", model);
        }
    }

    public class ArticleController : GlassController {            
        private readonly IArticleBusiness businessLogic;
        private readonly IArticleRedirectionService redirect;
        public ArticleController(IArticleBusiness businessLogic, IArticleRedirectionService redirect) {
            this.businessLogic = businessLogic;
            this.redirect = redirect;
        }
        public ActionResult Index() {
            // If a redirect has been configured for this Article, 
            // then redirect to new location.
            var url = redirect.CheckUrl();
            if(url != null) {
                return Redirect(url);
            }
            var model = businessLogic.FetchPopulatedModel;    
            return View("~/Views/EmailCampaign/EmailArticle.cshtml", model);
        }
    }

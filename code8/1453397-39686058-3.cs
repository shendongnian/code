        public class PageVisitCountFilter:ActionFilterAttribute
        {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
    
            PageVisit page = new PageVisit();
            var repository = new PageVisitRepository();
            var pageUrl = filterContext.HttpContext.Request.Url;
    
            var page = repository.GetPageByUrl(pageUrl);
            if(page == null)
            {
                page = new PageVisit { PageUrl = pageUrl, Visits = 1 };
                repository.Save(page);
            }
            else
            {
                page.Visits++;
                repository.Update(page);
            }
        }
        }

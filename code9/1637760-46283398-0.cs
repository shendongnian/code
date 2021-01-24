    public interface IArticleRedirectService {
        Url CheckUrl();
    }
    
    public class ArticleRedirectionService : IArticleRedirectionService {
        public Url CheckUrl() {            
            if (Sitecore.Context.Item.Fields[SitecoreFieldIds.WTW_REDIRECT_TO] != null && 
                !string.IsNullOrEmpty(Sitecore.Context.Item.Fields[SitecoreFieldIds.WTW_REDIRECT_TO].Value)) {
                var link = (LinkField)Sitecore.Context.Item.Fields[SitecoreFieldIds.WTW_REDIRECT_TO];
                if (link != null) {
                    if (link.IsInternal) {
                        return Sitecore.Links.LinkManager.GetItemUrl(link.TargetItem);
                    } else {
                        return link.Url;
                    }
                }
            }
            return null;
        }
    }

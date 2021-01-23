    public class PartialTagHelperBase : TagHelper
    {
        private IHtmlHelper                         m_HtmlHelper;
        public ShopStreetTagHelperBase(IHtmlHelper htmlHelper)
        {
            m_HtmlHelper = htmlHelper;
        }
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        protected async Task<IHtmlContent> RenderPartial<T>(string partialName, T model)
        {
            (m_HtmlHelper as IViewContextAware).Contextualize(ViewContext);
            return await m_HtmlHelper.PartialAsync(partialName, model);
        }
    }

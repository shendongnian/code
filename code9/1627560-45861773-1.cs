    public class PagerTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PagerTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageViewModel PageModel { get; set; }
        public string PageAction { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";
            // we put our links in list
            TagBuilder tag = new TagBuilder("ul");
            tag.AddCssClass("pagination");
            //show link for 1st page
            if (PageModel.PageNumber>2)
            {
                  TagBuilder fstItem = CreateTag(1, urlHelper);
                  tag.InnerHtml.AppendHtml(fstItem);
            }
  
            // create 3 links to current, next and previous page.
            TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper);
            // link to previous page if NOT 1st page
            if (PageModel.HasPreviousPage)
            {
                TagBuilder prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                tag.InnerHtml.AppendHtml(prevItem);
            }
            tag.InnerHtml.AppendHtml(currentItem);
            // link to next page, if NOT last page
            if (PageModel.HasNextPage)
            {
                TagBuilder nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                tag.InnerHtml.AppendHtml(nextItem);
            }
            //show code for last page
            if (PageModel.TotalPages > 4 && PageModel.PageNumber!=PageModel.TotalPages-1 && PageModel.HasNextPage)
            {
                TagBuilder lstItem = CreateTag(PageModel.TotalPages, urlHelper);
                tag.InnerHtml.AppendHtml(lstItem);
            }
            output.Content.AppendHtml(tag);
        }
        TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");
            if (pageNumber == this.PageModel.PageNumber)
            {
                item.AddCssClass("active");
            }
            else
            {
                link.Attributes["href"] = urlHelper.Action(PageAction, new { page = pageNumber });
            }
            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);
            return item;
        }
    }

     public override void Process(TagHelperContext context, TagHelperOutput output)
     {
         IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
         output.TagName = "div";
    
         // we put our links in list
         TagBuilder tag = new TagBuilder("ul");
         tag.AddCssClass("pagination");
    
         for (int i = 1; i <= PageModel.TotalPages; i++)
         {
             TagBuilder linkItem = CreateTag(i, urlHelper);
             tag.InnerHtml.AppendHtml(linkItem);
         }
    
         output.Content.AppendHtml(tag);
     }

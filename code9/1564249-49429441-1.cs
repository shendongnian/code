    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "pre";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.PostContent.SetContent("<h1>this gets HTML encoded<h1>");
        output.PostContent.SetHtmlContent("<h1>Hello World</h1>");
    }

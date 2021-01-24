    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var childContext = output.GetChildContentAsync().Result;
        var content = childContext.GetContent();
        // content == "Some content"
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var content = output.GetChildContentAsync().Result;
        // content == "Some content"
    }

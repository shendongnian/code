    public static MvcHtmlString DisplayPicture(this HtmlHelper html, string model)
    { 
        [...]
        string basePath = GetBasePath();
        return new MvcHtmlString("<img src=\"" + basePath + "/Content/images/image.png\" />");
    }

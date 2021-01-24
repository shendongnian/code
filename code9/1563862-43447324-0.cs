    internal static string DecimalTemplate(HtmlHelper html)
    {
        if (html.ViewContext.ViewData.TemplateInfo.FormattedModelValue == html.ViewContext.ViewData.ModelMetadata.Model)
        {
            html.ViewContext.ViewData.TemplateInfo.FormattedModelValue = String.Format(CultureInfo.CurrentCulture, "{0:0.00}", html.ViewContext.ViewData.ModelMetadata.Model);
        }
        return StringTemplate(html);
    }

    public static IHtmlContent DecimalTemplate(IHtmlHelper htmlHelper)
    {
            if (htmlHelper.ViewData.TemplateInfo.FormattedModelValue == htmlHelper.ViewData.Model)
            {
                htmlHelper.ViewData.TemplateInfo.FormattedModelValue =
                    string.Format(CultureInfo.CurrentCulture, "{0:0.00}", htmlHelper.ViewData.Model);
            }
            return StringTemplate(htmlHelper);
    }

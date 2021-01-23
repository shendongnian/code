    public static string GetString(IHtmlContent content)
    {
        var writer = new StringWriter();
        content.WriteTo(writer, HtmlEncoder.Default);
        return writer.ToString();
    }

    public static MvcHtmlString ActiveOrInactive(this HtmlHelper htmlHelper, decimal invNo)
    {
        var text = (invNo == 0) ? "InActive" : "Active";
        return new MvcHtmlString(text);
    }

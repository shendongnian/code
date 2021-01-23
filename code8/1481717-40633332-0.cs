    /// <summary>
    /// Convert bool value to javascript boolean (as string because it is placed in javascript)
    /// </summary>
    public static System.Web.IHtmlString ToJSBoolean(this bool value) {
        return new MvcHtmlString(value.ToString().ToLower());
    }

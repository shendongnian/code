    /// <summary>
    /// Turn the current request's querystring into the appropriate param for     <code>Html.BeginForm</code> or <code>Html.ActionLink</code>
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    /// <remarks>
    /// See discussions:
    /// * https://stackoverflow.com/questions/4675616/how-do-i-get-the-querystring-values-into-a-the-routevaluedictionary-using-html-b
    /// * https://stackoverflow.com/questions/6165700/add-query-string-as-route-value-dictionary-to-actionlink
    /// </remarks>
    public static RouteValueDictionary QueryStringAsRouteValueDictionary(this HtmlHelper html)
    {
    // shorthand
    var qs = html.ViewContext.RequestContext.HttpContext.Request.QueryString;
    // because LINQ is the (old) new black
    return qs.AllKeys.Aggregate(new RouteValueDictionary(html.ViewContext.RouteData.Values),
        (rvd, k) => {
            // can't separately add multiple values `?foo=1&foo=2` to dictionary, they'll be combined as `foo=1,2`
            //qs.GetValues(k).ForEach(v => rvd.Add(k, v));
            rvd.Add(k, qs[k]);
            return rvd;
        });
    }

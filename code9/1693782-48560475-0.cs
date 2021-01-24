    @functions
    {
        RouteValueDictionary MergeIn(IDictionary<string, object> original_data, object more_data)
        {
            var result = new RouteValueDictionary(original_data);
            foreach (var k in HtmlHelper.ObjectToDictionary(more_data)) 
            {
                result[k.Key] = k.Value;
            }
            return result;
        }
    }
    @{
        var query_values = new Dictionary<string, object>();
        this.Request.QueryString.CopyTo(query_values);
    }
    <ul class="list-inline">
        <li>
            @Html.ActionLink("English", null, MergeIn(query_values, new { culture = "en" }), HtmlHelper.ObjectToDictionary(new { rel = "alternate", hreflang = "en" }))
        </li>
        <li>
            @Html.ActionLink("中文", null, MergeIn(query_values, new { culture = "zh" }), HtmlHelper.ObjectToDictionary( new { rel = "alternate", hreflang = "zh" }))
        </li>
    </ul>

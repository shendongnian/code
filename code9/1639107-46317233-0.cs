    public static class AjaxHelperExtensions
    {
        public static MvcHtmlString ActionLinkUsingCollection(this AjaxHelper ajaxHelper, string linkText, string actionName, object model, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            var rv = new RouteValueDictionary();
            foreach (var property in model.GetType().GetProperties())
            {
                if (typeof(ICollection).IsAssignableFrom(property.PropertyType))
                {
                    var s = ((IEnumerable<object>)property.GetValue(model));
                    if (s != null && s.Any())
                    {
                        var values = s.Select(p => p.ToString()).Where(p => !string.IsNullOrEmpty(p)).ToList();
                        for (var i = 0; i < values.Count(); i++)
                            rv.Add(string.Concat(property.Name, "[", i, "]"), values[i]);
                    }
                }
                else
                {
                    var value = property.GetGetMethod().Invoke(model, null) == null ? "" : property.GetGetMethod().Invoke(model, null).ToString();
                    if (!string.IsNullOrEmpty(value))
                        rv.Add(property.Name, value);
                }
            }
            return AjaxExtensions.ActionLink(ajaxHelper, linkText, actionName, rv, ajaxOptions, htmlAttributes);
        }
    }

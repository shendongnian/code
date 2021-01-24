    using System.Collections.Generic;
    using System.Web.Routing;
    IDictionary<string, object> attrs = new RouteValueDictionary(htmlAttributes);
    string clazz;
    if (attrs.TryGetValue("class", out clazz))
    {
        attrs["class"] = clazz + " " + "currentMenuItem";
    }
    return helper.ActionLink(text, action, controller, attrs);

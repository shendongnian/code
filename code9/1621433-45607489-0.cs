    TagHelperAttribute forAttribute;
    if (!context.AllAttributes.TryGetAttribute("asp-for", out forAttribute))
    {
        throw new Exception("No asp-for attribute found.");
    }
    
    var forInfo = (Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression)forAttribute.Value;

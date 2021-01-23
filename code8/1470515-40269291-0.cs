    var existingClass = output.Attributes.FirstOrDefault(f => f.Name == "class");
    var cssClass = string.Empty;
    if (existingClass != null)
    {
        cssClass = existingClass.Value.ToString();       
    }
    cssClass = cssClass + " active";
    var ta = new TagHelperAttribute("class", cssClass);
    output.Attributes.Remove(existingClass);
    output.Attributes.Add(ta);
    

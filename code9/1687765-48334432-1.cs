    public HtmlGenericControl FindImg(HtmlGenericControl control)
    {            
        foreach (var child in control.Controls.OfType<HtmlGenericControl>())
        {
            if (child.TagName == "img") return child; //found img               
    
            //not found, recurse into child
            var result = FindImg(child);
            if (result != null) return result;
        }
        return null; //no img found
    }

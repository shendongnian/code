    TagBuilder name = new TagBuilder("span");
    name.InnerHtml.Append("John");
    
    TabBuilder container = null;
    if (Session.IsMaster()) {
        container = new TagBuilder("label");
        container.InnerHtml.Append("Our Master of Universe, ");
        container.InnerHtml.AppendHtml(name);
    }
    
    return container ?? name;

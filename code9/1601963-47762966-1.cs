    // document is current document returned from OpenAsync of an IBrowsingContext instance
    var topics = document.QuerySelectorAll("body > .topic-class");
    
    foreach (var topic in topics)
    {
        var topicTitle = topic.QuerySelector("h2")?.TextContent;
        var categories = topic.QuerySelectorAll(".category-class");
        foreach (var category of categories)
        {
            var categoryTitle = category.QuerySelector("h3")?.TextContent;
            var captions = category.QuerySelectorAll("a.caption-link");
           
            foreach (IHtmlAnchorElement caption of captions)
            {
                var captionTitle = caption.TextContent;
                var link = caption.Href;
            }
        }
    }

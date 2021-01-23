        //parsing a http-served url (asynchronous, used .Result here for simplification, but this defeats the asynchronoability of the code)
        IBrowsingContext bc = BrowsingContext.New();
        Task<IDocument> doc = bc.OpenAsync("yourAddress");
        //querying a single selector match
        IElement element1 = doc.Result.QuerySelector(".yourSelector");
        //querying multiple selector matches
        IEnumerable<IElement> elements1 = doc.Result.QuerySelectorAll(".yourSelectors");
        //parsing a physical html document, non-network dependent
        HtmlParser parser = new HtmlParser();
        IHtmlDocument doc2 = parser.Parse("htmlFile");
        IElement element2 = doc.Result.QuerySelector(".yourSelector");
        IEnumerable<IElement> elements2 = doc.Result.QuerySelectorAll(".yourSelectors");

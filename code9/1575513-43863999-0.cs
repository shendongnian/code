    const string xml = @"<units>
                    <author-group>
                    <root>
                        <author Seq=""1"">
                        <initials>J.</initials>
                        <surname>Kim</surname>
                        <given-name>Jiyeon</given-name>
                        </author>
                        <author Seq=""2"">
                        <initials>k.</initials>
                        <surname>Kim</surname>
                        <given-name>ki</given-name>
                        </author>
                    </root>
                    </author-group>
                </units>";
    
    const string elementToRemove = "root";
    const string addElementsInElement = "author-group";
    
    var doc = XDocument.Parse(xml);
    
    var matchingElement = doc
                            .Descendants()
                            .First(e => e.Element(elementToRemove) != null);
    
    var innerElements = matchingElement.Elements().Elements().ToList();
    
    doc
        .Descendants()
        .First(e => e.Element(elementToRemove) != null)
        .RemoveNodes();
    
    doc
        .Descendants()
        .First(e => e.Element(addElementsInElement) != null)
        .Element(addElementsInElement)
        .Add(innerElements);

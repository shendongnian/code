    [XmlRoot(ElementName = "Query", Namespace = "http://opensearch.org/searchsuggest2")]
    public class Query
    {
        [XmlAttribute(AttributeName = "space", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Space { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    [XmlRoot(ElementName = "Text", Namespace = "http://opensearch.org/searchsuggest2")]
    public class Text
    {
        [XmlAttribute(AttributeName = "space", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Space { get; set; }
        [XmlText]
        public string text { get; set; }
    }
    [XmlRoot(ElementName = "Url", Namespace = "http://opensearch.org/searchsuggest2")]
    public class Url
    {
        [XmlAttribute(AttributeName = "space", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Space { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    [XmlRoot(ElementName = "Description", Namespace = "http://opensearch.org/searchsuggest2")]
    public class Description
    {
        [XmlAttribute(AttributeName = "space", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Space { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    [XmlRoot(ElementName = "Image", Namespace = "http://opensearch.org/searchsuggest2")]
    public class Image
    {
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlAttribute(AttributeName = "width")]
        public string Width { get; set; }
        [XmlAttribute(AttributeName = "height")]
        public string Height { get; set; }
    }
    [XmlRoot(ElementName = "Item", Namespace = "http://opensearch.org/searchsuggest2")]
    public class Items
    {
        [XmlElement(ElementName = "Text", Namespace = "http://opensearch.org/searchsuggest2")]
        public Text Text { get; set; }
        [XmlElement(ElementName = "Url", Namespace = "http://opensearch.org/searchsuggest2")]
        public Url Url { get; set; }
        [XmlElement(ElementName = "Description", Namespace = "http://opensearch.org/searchsuggest2")]
        public Description Description { get; set; }
        [XmlElement(ElementName = "Image", Namespace = "http://opensearch.org/searchsuggest2")]
        public Image Image { get; set; }
    }
    [XmlRoot(ElementName = "Section", Namespace = "http://opensearch.org/searchsuggest2")]
    public class Section
    {
        [XmlElement(ElementName = "Item", Namespace = "http://opensearch.org/searchsuggest2")]
        public List<Items> Item { get; set; }
    }
    [XmlRoot(ElementName = "SearchSuggestion", Namespace = "http://opensearch.org/searchsuggest2")]
    public class SearchItem
    {
        [XmlElement(ElementName = "Query", Namespace = "http://opensearch.org/searchsuggest2")]
        public Query Query { get; set; }
        [XmlElement(ElementName = "Section", Namespace = "http://opensearch.org/searchsuggest2")]
        public Section Section { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }

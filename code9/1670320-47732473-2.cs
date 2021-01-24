    [XmlRoot(ElementName = "book")]
    public class Book
    {
        [XmlElement(ElementName = "author")]
        public string Author { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "genre")]
        public Genre Genre { get; set; }
        [XmlElement(ElementName = "price")]
        public decimal Price { get; set; }
        [XmlElement(ElementName = "publish_date")]
        public string PublishDate { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
    [XmlRoot(ElementName = "catalog")]
    public class Catalog
    {
        [XmlElement(ElementName = "book")]
        public List<Book> Books { get; set; }
    }
    public enum Genre
    {
        Computer,
        Fantasy,
    };

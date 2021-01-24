    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    
    static class P
    {
        static void Main()
        {
            var xml = @"<library>
    <books>
     <a><author>x</author><details>1</details></a>
     <b><author>y</author><details>2</details></b>
     <c><author>z</author><details>3</details></c>
    </books>
    </library>";
            var doc = new XmlDocument();
            doc.LoadXml(xml);
    
            var ser = new XmlSerializer(typeof(Book));
    
            List<Book> books = new List<Book>();
            foreach (XmlElement book in doc.SelectNodes("/library/books/*"))
            {
                var el = doc.CreateElement("book");
                el.SetAttribute("name", book.Name);
                foreach (XmlNode child in book.ChildNodes)
                {
                    el.AppendChild(child.Clone());
                }
    
                using (var reader = new XmlNodeReader(el))
                {
                    books.Add((Book)ser.Deserialize(reader));
                }
            }
    
            foreach(var book in books)
            {
                System.Console.WriteLine(book);
            }
    
        }
    }
    [XmlRoot("book")]
    public class Book
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("author")]
        public string Author { get; set; }
        [XmlElement("details")]
        public string Details { get; set; }
    
        public override string ToString() => $"{Name} by {Author}: {Details}";
    }

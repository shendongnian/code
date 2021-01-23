    #region Usings
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    #endregion
    public class Program
    {
        /// <summary>
        /// This method reads an xml file.
        /// Finds the element to change.
        /// Changes the Title.
        /// And Finally saves the changes back to the xml file.
        /// </summary>
        public void Main()
        {
            // The file path of the XML document.
            string filePath = "document.xml";
            // Initializing the book store variable.
            BookStore bookStore = null;
            // Initializing the reading and writing of the XML file.
            using (StreamReader fileReadStream = new StreamReader(filePath))
            using (StreamWriter fileWriteStream = new StreamWriter(filePath))
            {
                // Initializing the serializer.
                XmlSerializer serializer = new XmlSerializer(typeof(BookStore));
                // De-serializing the XML file to objects.
                bookStore = (BookStore)serializer.Deserialize(fileReadStream);
                // Finding the required element.
                Book book = bookStore.Book.Single(b => b.Category.Equals("children") &&
                                                       b.Title.Lang.Equals("en") &&
                                                       b.Title.Value.Equals("Harry Potter"));
                // Setting the new title of the book.
                book.Title.Value = "New Title";
                // Saving the changes back to the XML file.
                serializer.Serialize(fileWriteStream, bookStore);
            }
        }
    }
    #region BookStore Classes
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class BookStore
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("book")]
        public IEnumerable<Book> Book { get; set; }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Book
    {
        /// <remarks/>
        public BookStoreBookTitle Title { get; set; }
        /// <remarks/>
        public string Author { get; set; }
        /// <remarks/>
        public ushort Year { get; set; }
        /// <remarks/>
        public decimal Price { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Category { get; set; }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class BookStoreBookTitle
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Lang { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }
    #endregion

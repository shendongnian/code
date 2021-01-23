    public partial class Products{
    
       [XmlArray("Product")] 
       [XmlElement("productName")]
       public List<string> productName { get; set; }
    }

    1.Please Add using System.Xml as a reference;
    2.Make a class named book in this way
   
         public class book
                {
                    public Nullable<System.DateTime> date{ get; set; }
                    public decimal price { get; set; }
                    public string title { get; set; }
                    public string description { get; set; }
            }
    
        try
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load("Write down full path");
                        XmlNodeList dataNodes = xmlDoc.SelectNodes("/catalog");
        
                        foreach (XmlNode node in dataNodes)
                        {
                            book objbook = new book();
                         objbook.date=Convert.ToDateTime(node.Attributes["date"].Value);
                           objbook.title=node.SelectSingleNode("title").InnerText;
                       objbook.description=node.SelectSingleNode("description").InnerText;
    objbook.price=Convert.ToDecimal(node.SelectSingleNode("price").InnerText);
    
                        }
    
                    }
    catch(Exception ex)
    {
    throw ex;
    }

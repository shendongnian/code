    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Linq;
    
    class Program
    {
         public class Product
            {
                public Product()
                { }
        
                public Product(string name,int code, List<productType> types)
                {
                    this.Name = name;
                    this.Code = code;
                    this.types = types;
                }
        
                public string Name { get; set; }
                private int Code { get; set; }
                public List<productType> types { get; set; }
        
                public string Serialize(List<Product> products)
                {
                    XElement productSer = new XElement("Products",
                   from c in products
                   orderby c.Code
                   select new XElement("product",
                       new XElement("Code", c.Code),
                       new XElement("Name", c.Name),
                       new XElement("Types", (from x in c.types
                                              orderby x.type//descending 
                                               select new XElement("Type", x.type))
                   ))
              );
                    return productSer.ToString();
                }
            }
            public class productType
            {
                public string type { get; set; }
            }
    
     public static void Main()
        {    
            List<productType> typ = new List<productType>();
            typ.Add((new productType() { type = "Type1" }));
            typ.Add((new productType() { type = "Type2" }));
            typ.Add((new productType() { type = "Type3" }));
    
            List<Product> products =new List<Product>() { new Product ( "apple", 9,typ) ,
                          new Product ("orange", 4,typ   ),
                          new Product ("apple", 9 ,typ),
                          new Product ("lemon", 9,typ ) };
    
       Console.WriteLine(new Product().Serialize(products));
            Console.ReadLine();
     }
    }

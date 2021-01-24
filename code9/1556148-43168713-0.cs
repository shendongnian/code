    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                XDocument xmlDoc = new XDocument();
                XElement users = new XElement("users");
                xmlDoc.Add(users);
                foreach (var user in cUser.users)
                {
                   XElement newUser =  new XElement("user", 
                       new XAttribute("first-name", user.FirstName?? ""), 
                       new XAttribute("last-name", user.LastName?? ""),
                       new XElement("sold-products")
                   );
                   users.Add(newUser);
                   foreach (Product product in user.products)
                   {
                      newUser.Add(new XElement("Product",
                         new XElement("name", product.Name),
                         new XElement("price", product.Price)
                      ));
                   }
                }
            }
        }
        public class cUser
        {
            public static List<cUser> users { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<Product> products { get; set; }
        }
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }

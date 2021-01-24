    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Category.categories = doc.Descendants("Category").Select(x => new Category() {
                    BestOfferEnabled = (Boolean)x.Element("BestOfferEnabled"),
                    AutoPayEnabled = (Boolean)x.Element("BestOfferEnabled"),
                    CategoryID = (int)x.Element("CategoryID"),
                    CategoryLevel = (int)x.Element("CategoryLevel"),
                    CategoryName = (string)x.Element("CategoryName"),
                    CategoryParentID = (int)x.Element("CategoryParentID"),
                }).ToList();
                int id = 37903;
                Category categoryId = Category.categories.Where(x => x.CategoryParentID == id).FirstOrDefault();
            }
        }
        public class Category
        {
            public static List<Category> categories { get; set; }
            public Boolean  BestOfferEnabled { get; set; }        
            public Boolean  AutoPayEnabled { get; set; }
            
            public int CategoryID { get; set; }
            public int CategoryLevel { get; set; }
            public string CategoryName { get; set; }
            public int CategoryParentID { get; set; }
        }
    }

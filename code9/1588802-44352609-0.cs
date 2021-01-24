    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Link", typeof(string));
                dt.Columns.Add("IsPermaLink", typeof(Boolean));
                dt.Columns.Add("GUID", typeof(string));
                dt.Columns.Add("Publish Date", typeof(DateTime));
                dt.Columns.Add("Width", typeof(int));
                dt.Columns.Add("Height", typeof(int));
                dt.Columns.Add("URL", typeof(string));
                XDocument doc = XDocument.Load(FILENAME); //or uri
                List<XElement> items = doc.Descendants("item").ToList();
                foreach (XElement item in items)
                {
                    dt.Rows.Add(new object[] {
                        (string)item.Element("title"),
                        (string)item.Element("description"),
                        (string)item.Element("link"),
                        (Boolean)item.Element("guid").Attribute("isPermaLink"),
                        (string)item.Element("guid"),
                        (DateTime)item.Element("pubDate"),
                        (int)item.Elements().Where(x => x.Name.LocalName == "thumbnail").FirstOrDefault().Attribute("width"),
                        (int)item.Elements().Where(x => x.Name.LocalName == "thumbnail").FirstOrDefault().Attribute("height"),
                        (string)item.Elements().Where(x => x.Name.LocalName == "thumbnail").FirstOrDefault().Attribute("url")
                    });
                }
                
            }
        }
     
    }

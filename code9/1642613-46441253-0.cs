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
                string city = "London";
                string uri = string.Format("http://api.apixu.com/v1/current.xml?key=02d3de968c424e20b5a74149172409&q={0}&mode=xml", city);
                XDocument doc = XDocument.Load(uri);
                string temp = (string)doc.Descendants("temp_c").FirstOrDefault();
                string humidity = (string)doc.Descendants("humidity").FirstOrDefault();
            }
        }
     
    }

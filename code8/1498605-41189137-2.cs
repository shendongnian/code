    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication33
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Image.images = doc.Descendants("struct").FirstOrDefault().Elements("member").Select(x => new Image() {
                    name = (int)x.Element("name"),
                    imageID = x.Descendants("member").Where(y => (string)y.Element("name") == "imageID").Select(z => (int)z.Descendants("string").FirstOrDefault()).FirstOrDefault(),
                    url = x.Descendants("member").Where(y => (string)y.Element("name") == "imageURL").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault(),
                }).ToList();
            }
        }
        public class Image
        {
            public static List<Image> images { get; set; }
            public int name { get; set; }
            public int imageID { get; set; }
            public string url { get; set; }
        }
    }

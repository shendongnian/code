    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication74
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<MyClass> myClasses = doc.Descendants("Obj").Select(x => new MyClass() {
                    Id = (int)x.Element("Id"),
                    dict1 = x.Elements("NameValuePair").GroupBy(y => (string)y.Element("Name"), z => (string)z.Element("Value"))
                            .ToDictionary(y => y.Key, z => z.FirstOrDefault()),
                    dict2 = x.Elements("NameValuePair").GroupBy(y => (string)y.Element("Name"), z => (string)z.Element("Value"))
                            .ToDictionary(y => y.Key, z => z.ToList())
                }).ToList();
            }
        }
        internal class MyClass
        {
            public int Id { get; internal set; }
            public Dictionary<string,string> dict1 { get; set; }
            public Dictionary<string, List<string>> dict2 { get; set; }
        } 
    }
